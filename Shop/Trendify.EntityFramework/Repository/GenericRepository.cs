using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Trendify.EntityFramework.Repository;

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

    public async Task<T?> Find(Guid id) => await _table.FindAsync(id);

    public IQueryable<T> GetAll() => _table.AsNoTracking();

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression) => _table.Where(expression).AsNoTracking();

    public async Task<T?> GetBy(Expression<Func<T, bool>> expression) => await _table.FirstOrDefaultAsync(expression);

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