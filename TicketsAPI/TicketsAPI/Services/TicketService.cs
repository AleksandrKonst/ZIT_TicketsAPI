using AutoMapper;
using TicketsAPI.Data;
using TicketsAPI.DTO;
using TicketsAPI.Middleware.Exceptions;
using TicketsAPI.Models;

namespace TicketsAPI.Services;

public class TicketService : ITicketService
{
    private readonly IMapper _mapper;
    private readonly TicketContext _context;

    public TicketService(TicketContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task <TicketSaleDto> PostTicketSale(TicketSaleDto ticketSaleDto)
    {
        int serialNumberIncrement = 1;
        foreach (var t in ticketSaleDto.routes)
        {
            var ticketSale = _mapper.Map<Segment>(ticketSaleDto);
            ticketSale.serial_number = serialNumberIncrement;
            ticketSale.airline_code = t.airline_code;
            ticketSale.flight_num = t.flight_num;
            ticketSale.depart_place = t.depart_place;
            ticketSale.depart_datetime = DateTime.Parse(t.depart_datetime).ToUniversalTime();
            ticketSale.depart_datetime_timezone = (short)(DateTimeOffset.Parse(t.depart_datetime).Offset.Hours * -1);
            ticketSale.arrive_place = t.arrive_place;
            ticketSale.arrive_datetime = DateTime.Parse(t.arrive_datetime).ToUniversalTime();
            ticketSale.arrive_datetime_timezone = (short)(DateTimeOffset.Parse(t.arrive_datetime).Offset.Hours * -1);
            ticketSale.pnr_id = t.pnr_id;
            serialNumberIncrement++;
            await _context.Segments.AddAsync(ticketSale);
        }
        await _context.SaveChangesAsync();
        return ticketSaleDto;
    }

    public async Task<TicketRefundDto> PostTicketRefund(TicketRefundDto ticketRefundDto)
    {
        var allTicket = _context.Segments.Where(t =>
            t.ticket_number == ticketRefundDto.ticket_number && t.operation_type == "sale");
        if (!allTicket.Any())
        {
            throw new RefundTicketNumberIsNotFound("TicketNumber is not found");
        }
        foreach (var t in allTicket)
        {
            t.operation_type = ticketRefundDto.operation_type;
            
        }
        await _context.SaveChangesAsync();
        return ticketRefundDto;
    }
}