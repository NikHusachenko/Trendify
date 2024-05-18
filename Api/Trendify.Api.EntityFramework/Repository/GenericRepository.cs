using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Repository;

public sealed class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _table;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task Create(T entity, CancellationToken cancellationToken = default)
    {
        entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateTime.Now.ToUniversalTime();
        entity.UpdatedAt = DateTime.Now.ToUniversalTime();

        await _table.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSoft(T entity)
    {
        entity.DeletedAt = DateTime.Now.ToUniversalTime();

        _table.Update(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll() => 
        _table.Where(entity => !entity.DeletedAt.HasValue).AsNoTracking();

    public IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate) =>
        _table.Where(entity => !entity.DeletedAt.HasValue)
            .Where(predicate)
            .AsNoTracking();

    public async Task<T?> GetBy(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) =>
        await _table
            .Where(entity => !entity.DeletedAt.HasValue)
            .FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task<T?> GetById(Guid id, CancellationToken cancellationToken = default) =>
        await _table.FirstOrDefaultAsync(entity => 
            entity.Id == id &&
            !entity.DeletedAt.HasValue,
            cancellationToken);

    public async Task Update(T entity)
    {
        _table.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHard(T entity)
    {
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRange(List<T> entities)
    {
        _table.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
}