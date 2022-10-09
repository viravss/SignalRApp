using System.Linq.Expressions;
using Application.Repositories;
using Domain.Common;
using Domain.Enums;
using Nest;

namespace Infrastructure.Services;

public class CommonService<T> : ICommonServices<T> where T : BaseEntity
{
    private readonly ICommonRepositories<T> _repositories;

    public CommonService(ICommonRepositories<T> repositories)
    {
        _repositories = repositories;
    }

    public async Task CheckIndexAsync(IndicesEnum indexName)
    {
        await _repositories.CheckIndexAsync(indexName);
    }

    public async Task InsertDocumentAsync(IndicesEnum indexName, T entity)
    {
        await _repositories.InsertDocumentAsync(indexName.ToString(), entity);
    }

    public async Task DeleteIndexAsync(IndicesEnum indexName, T entity)
    {
        await _repositories.DeleteIndexAsync(indexName.ToString(), entity);
    }

    public async Task InsertBulkDocumentAsync(IndicesEnum indexName, List<T> entities)
    {
        await _repositories.InsertBulkDocumentAsync(indexName.ToString(), entities);
    }

    public async Task<T> GetDocumentAsync(IndicesEnum indexName, string id)
    {
        return await _repositories.GetDocumentAsync(indexName.ToString(), id);
    }

    public async Task<List<T>> GetDocumentsAsync(string indexName, Func<QueryContainerDescriptor<T>, QueryContainer> conditions)
    {
        return await _repositories.GetDocumentAsync(indexName.ToString(), conditions);
    }
}