using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Trendify.Api.EntityFramework.Repository;

public sealed class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _table;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task Create(T entity)
    {
        await _table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task CreateRange(List<T> entities)
    {
        await _table.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRange(List<T> entities)
    {
        _table.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll() => 
        _table.AsNoTracking();

    public IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate) =>
        _table.Where(predicate).AsNoTracking();

    public async Task<T?> GetBy(Expression<Func<T, bool>> predicate) =>
        await _table.FirstOrDefaultAsync(predicate);

    public async Task<T?> GetById(Guid id) => 
        await _table.FindAsync(id);

    public async Task Update(T entity)
    {
        _table.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRange(List<T> entities)
    {
        _table.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
}