using System.Linq.Expressions;
using Domain.Common;
using Domain.Enums;
using Nest;

namespace Application.Repositories;

public interface ICommonRepositories<T> where T : BaseEntity
{

    Task CheckIndexAsync(IndicesEnum indexName);
    Task InsertDocumentAsync(string indexName, T entity);
    Task DeleteIndexAsync(string indexName, T entity);
    Task<BulkResponse> InsertBulkDocumentAsync(string indexName, List<T> entities);
    Task<T> GetDocumentAsync(string indexName, string id);
    Task<List<T>> GetDocumentAsync(string indexName , Func<QueryContainerDescriptor<T>, QueryContainer> conditions);






    //Task<IReadOnlyList<T>> GetAllAsync();
    //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    //Task<T> GetByIdAsync(Guid id);
    //Task<T> AddAsync(T entity);
    //void UpdateAsync(T entity);
    //void DeleteAsync(T entity);
}