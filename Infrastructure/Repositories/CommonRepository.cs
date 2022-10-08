using System.Linq.Expressions;
using Domain.Common;
using Domain.Enums;
using Infrastructure.Mapping;
using Microsoft.Extensions.Configuration;
using Nest;
using Index = System.Index;

namespace Infrastructure.Repositories;
using Application.Repositories;
public class CommonRepository<T> : ICommonRepositories<T> where T : BaseEntity
{
    private readonly IConfiguration _configuration;

    private readonly IElasticClient _client;
    public CommonRepository(IConfiguration configuration, IElasticClient client)
    {
        _configuration = configuration;
        _client = CreateInstance();
    }
    #region Instance 
    private ElasticClient CreateInstance()
    {
        var host = _configuration.GetSection("Elastic:host").Value;
        var port = _configuration.GetSection("Elastic:post").Value;
        var userName = _configuration.GetSection("Elastic:userName").Value;
        var password = _configuration.GetSection("Elastic:password").Value;
        var settings = new ConnectionSettings(new Uri($"{host}:{port}"));
        if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            settings.BasicAuthentication(userName, password);
        return new ElasticClient(settings);
    }
    #endregion
    public async Task CheckIndexAsync(IndicesEnum indexName)
    {
        var any = await _client.Indices.ExistsAsync(indexName.ToString());
        if (any.Exists)
            return;

        switch (indexName)
        {
            case IndicesEnum.User:
                await _client.Indices.CreateAsync(indexName.ToString(), ci => ci
                     .Index(indexName.ToString())
                     .UserMapping()
                     .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1)));
                break;
            case IndicesEnum.Message:
                await _client.Indices.CreateAsync(indexName.ToString(), ci => ci
                    .Index(indexName.ToString())
                    .MessageMapping()
                    .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1)));
                break;
        }
        return;
    }

    public async Task InsertDocumentAsync(string indexName, T entity)
    {
        var response = await _client.CreateAsync(entity, q => q.Index(indexName));
        if (response.ApiCall?.HttpStatusCode == 409)
        {
            await _client.UpdateAsync<T>(entity.Id, r => r.Index(indexName).Doc(entity));
        }
    }

    public async Task DeleteIndexAsync(string indexName, T entity)
    {
        var response = await _client.CreateAsync(entity, q => q.Index(indexName));
        if (response.ApiCall?.HttpStatusCode == 409)
        {
            await _client.DeleteAsync(DocumentPath<T>.Id(entity.Id).Index(indexName));
        }

    }

    public async Task<BulkResponse> InsertBulkDocumentAsync(string indexName, List<T> entities)
    {
        return await _client.IndexManyAsync(entities, index: indexName);
    }

    public async Task<T> GetDocumentAsync(string indexName, string id)
    {
        var result = await _client.GetAsync<T>(id, e => e.Index(indexName));
        return result.Source;
    }

    public async Task<List<T>> GetDocumentAsync(string indexName, Func<QueryContainerDescriptor<T>, QueryContainer> conditions)
    {

        var result = await _client.SearchAsync<T>(r => r
            .Index(indexName)
            .Query(conditions));
        return result.Documents.ToList();
    }
}