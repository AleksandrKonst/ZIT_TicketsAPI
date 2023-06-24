using TicketsAPI.Data;
using TicketsAPI.DTO;
using TicketsAPI.Models;
using TicketsAPI.Repository.Base;
using TicketsAPI.Repository.Interface;

namespace TicketsAPI.Repository;

public class TicketRepository : BaseRepository<Segment>, ITicketRepository
{
    public TicketRepository(TicketContext dbContext) : base(dbContext)
    {
        
    }
    
    public async Task<IEnumerable<Segment>> GetWhere(TicketRefundDto ticketRefundDto)
    {
        return await GetManyAsync(
            filter : t => t.ticket_number == ticketRefundDto.ticket_number && t.operation_type == "sale");
    }
}