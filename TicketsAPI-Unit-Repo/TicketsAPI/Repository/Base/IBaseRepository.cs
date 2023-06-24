using System.Linq.Expressions;

namespace TicketsAPI.Repository.Base;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    
    Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? top  = null,
        int? skip = null,
        params string[] includeProperties);
}