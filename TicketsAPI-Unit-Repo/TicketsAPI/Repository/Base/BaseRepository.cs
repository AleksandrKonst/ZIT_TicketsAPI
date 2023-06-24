using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TicketsAPI.Repository.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<T>  _dbSet;
    
    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    
    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }
    
    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task<IEnumerable<T>> GetManyAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? top  = null,
        int? skip = null,
        params string[] includeProperties)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties.Length > 0)
        {
            query = includeProperties.Aggregate(query, (theQuery, theInclude) => theQuery.Include(theInclude));
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (top.HasValue)
        {
            query = query.Take(top.Value);
        }

        return await query.ToListAsync();
    }
}