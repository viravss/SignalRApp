using System.Linq.Expressions;
using Domain.Common;
using Domain.Enums;
using Nest;

namespace Application.Repositories;

public interface ICommonServices<T> where T : BaseEntity
{
    Task CheckIndexAsync(IndicesEnum indexName);
    Task InsertDocumentAsync(IndicesEnum indexName, T entity);
    Task DeleteIndexAsync(IndicesEnum indexName, T entity);
    Task InsertBulkDocumentAsync(IndicesEnum indexName, List<T> entities);
    Task<T> GetDocumentAsync(IndicesEnum indexName, string id);
    Task<List<T>> GetDocumentsAsync(string indexName, Func<QueryContainerDescriptor<T>, QueryContainer> conditions);
}