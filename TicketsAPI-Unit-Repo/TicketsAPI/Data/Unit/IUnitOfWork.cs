using TicketsAPI.Repository.Interface;

namespace TicketsAPI.Data.Unit;

public interface IUnitOfWork : IAsyncDisposable
{
    ITicketRepository TicketRepository { get; }

    Task CompleteAsync();
}