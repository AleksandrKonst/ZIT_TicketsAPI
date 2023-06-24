using TicketsAPI.DTO;

namespace TicketsAPI.Services;

public interface ITicketService
{
    Task <TicketSaleDto> PostTicketSale(TicketSaleDto ticketDto);
    Task<TicketRefundDto> PostTicketRefund(TicketRefundDto ticketRefundDto);
}