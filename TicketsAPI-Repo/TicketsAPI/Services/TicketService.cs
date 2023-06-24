using AutoMapper;

using TicketsAPI.DTO;
using TicketsAPI.Middleware.Exceptions;
using TicketsAPI.Models;
using TicketsAPI.Repository.Interface;

namespace TicketsAPI.Services;

public class TicketService : ITicketService
{
    private readonly IMapper _mapper;
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository, IMapper mapper)
    {
        _mapper = mapper;
        _ticketRepository = ticketRepository;
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
            await _ticketRepository.AddAsync(ticketSale);
        }
        await _ticketRepository.SaveAsync();
        return ticketSaleDto;
    }

    public async Task<TicketRefundDto> PostTicketRefund(TicketRefundDto ticketRefundDto)
    {
        var allTicket = _ticketRepository.GetAsync().Result.Where(t =>
            t.ticket_number == ticketRefundDto.ticket_number && t.operation_type == "sale");
        if (!allTicket.Any())
        {
            throw new RefundTicketNumberIsNotFound("TicketNumber is not found");
        }
        foreach (var t in allTicket)
        {
            t.operation_type = ticketRefundDto.operation_type;
            
        }
        await _ticketRepository.SaveAsync();
        return ticketRefundDto;
    }
}