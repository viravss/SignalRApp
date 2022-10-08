using System.Linq.Expressions;
using Domain.Common;

namespace Application.Repositories;

public interface ICommonServices<T> where T : BaseEntity
{
    Task CheckIndexAsync(string indexName);
    Task InsertDocumentAsync(string indexName, T entity);
    Task DeleteIndexAsync(string indexName, T entity);
    Task InsertBulkDocumentAsync(string indexName, string id);
    Task<T> GetDocumentAsync(string indexName, string id);
    Task<List<T>> GetDocumentAsync(string indexName);
}