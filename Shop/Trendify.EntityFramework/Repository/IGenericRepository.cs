using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Trendify.EntityFramework.Repository;

public interface IGenericRepository<T> where T : class
{
    Task Create(T entity);
    Task CreateRange(List<T> entities);
    Task Update(T entity);
    Task UpdateRange(List<T> entities);
    Task Delete(T entity);
    Task DeleteRange(List<T> entities);

    Task<T?> Find(Guid id);
    Task<T?> GetBy(Expression<Func<T, bool>> expression);

    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
}