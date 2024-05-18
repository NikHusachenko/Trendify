using System.Linq.Expressions;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task Create(T entity, CancellationToken cancellationToken = default);
    Task Update(T entity);
    Task UpdateRange(List<T> entities);
    Task DeleteSoft(T entity);
    Task DeleteHard(T entity);

    Task<T?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<T?> GetBy(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    IQueryable<T> GetAll();
    IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate);
}