using TicketsAPI.Data;
using TicketsAPI.Models;
using TicketsAPI.Repository.Interface;

namespace TicketsAPI.Repository;

public class TicketRepository : ITicketRepository, IAsyncDisposable
{
    private readonly TicketContext _context;

    public TicketRepository(TicketContext context)
    {
        this._context = context;
    }

    public async Task<Segment?> GetByIdAsync(int id)
    {
        return await _context.Segments.FindAsync(id);
    }

    public async Task<IQueryable<Segment>> GetAsync()
    {
        return _context.Segments;
    }

    public async Task AddAsync(Segment segment)
    {
        await _context.Segments.AddAsync(segment);
    }
    
    public async Task DeleteAsync(int id)
    {
        var segment = await _context.Segments.FindAsync(id);
        if (segment != null) _context.Segments.Remove(segment);
    }
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed;
        
    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
        
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                await _context.DisposeAsync();
            }
            _disposed = true;
        }
    }
}