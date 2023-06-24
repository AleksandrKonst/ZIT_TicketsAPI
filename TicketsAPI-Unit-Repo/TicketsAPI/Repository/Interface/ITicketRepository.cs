using TicketsAPI.DTO;
using TicketsAPI.Models;
using TicketsAPI.Repository.Base;

namespace TicketsAPI.Repository.Interface;

public interface ITicketRepository : IBaseRepository<Segment>
{
    Task<IEnumerable<Segment>> GetWhere(TicketRefundDto ticketRefundDto);
}