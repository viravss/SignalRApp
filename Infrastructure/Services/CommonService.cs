using System.Linq.Expressions;
using Application.Repositories;
using Domain.Common;

namespace Infrastructure.Services;

public class CommonService<T> : ICommonServices<T> where T : BaseEntity
{
    public Task CheckIndexAsync(string indexName)
    {
        throw new NotImplementedException();
    }

    public Task InsertDocumentAsync(string indexName, T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteIndexAsync(string indexName, T entity)
    {
        throw new NotImplementedException();
    }

    public Task InsertBulkDocumentAsync(string indexName, string id)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetDocumentAsync(string indexName, string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetDocumentAsync(string indexName)
    {
        throw new NotImplementedException();
    }
}