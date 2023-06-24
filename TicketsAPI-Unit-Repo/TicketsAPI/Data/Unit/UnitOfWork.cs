using TicketsAPI.Repository;
using TicketsAPI.Repository.Interface;

namespace TicketsAPI.Data.Unit;

public class UnitOfWork : IUnitOfWork
{

        private TicketRepository _ticketRepository;
        public ITicketRepository TicketRepository => _ticketRepository ?? (_ticketRepository = new TicketRepository(_dbContext));

        private readonly TicketContext _dbContext;
        
        public UnitOfWork(TicketContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task CompleteAsync() => await _dbContext.SaveChangesAsync();

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
                    await _dbContext.DisposeAsync();
                }
                _disposed = true;
            }
        }
}