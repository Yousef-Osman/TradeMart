using Microsoft.EntityFrameworkCore;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Infrastructure.Data;

namespace TradeMart.Infrastructure.Repositories;
public class GenericRepository<T>: IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context; 
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> GetDataQuery()
    {
        return _dbSet;
    }

    public async Task<T> GetByIdAsync<G>(G id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void AddRange(List<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(List<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Delete<G>(G id)
    {
        T entity = _dbSet.Find(id);
        _dbSet.Remove(entity);
    }

    public void DeleteRange(List<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
