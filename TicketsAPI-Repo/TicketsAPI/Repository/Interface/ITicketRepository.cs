using TicketsAPI.Models;

namespace TicketsAPI.Repository.Interface;

public interface ITicketRepository
{
    Task<Segment?> GetByIdAsync(int id);

    Task<IQueryable<Segment>> GetAsync();
    
    Task AddAsync(Segment segment);
    
    Task DeleteAsync(int id);
    
    Task SaveAsync();
}