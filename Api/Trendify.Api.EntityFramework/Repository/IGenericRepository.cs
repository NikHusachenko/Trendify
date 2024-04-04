using System.Linq.Expressions;

namespace Trendify.Api.EntityFramework.Repository;

public interface IGenericRepository<T> where T : class
{
    Task Create(T entity);
    Task CreateRange(List<T> entities);
    Task Update(T entity);
    Task UpdateRange(List<T> entities);
    Task Delete(T entity);
    Task DeleteRange(List<T> entities);

    Task<T?> GetById(Guid id);
    Task<T?> GetBy(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetAll();
    IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate);
}