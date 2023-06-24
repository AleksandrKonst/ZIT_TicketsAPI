using Microsoft.AspNetCore.Mvc;
using TicketsAPI.DTO;
using TicketsAPI.Models;
using TicketsAPI.Services;

namespace TicketsAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
public class TicketsApiController : ControllerBase
{
    private readonly ITicketService _service;

    public TicketsApiController(ITicketService service)
    {
        _service = service;
    }
    [Route("api/v{version:apiVersion}/process/sale/")]
    [RequestSizeLimit(2 * 1024)]
    [HttpPost]
    public async Task<ActionResult<Segment>> PostTicketSale(TicketSaleDto ticketSaleDto)
    {
        await _service.PostTicketSale(ticketSaleDto);
        return Ok();
    }
    
    
    [RequestSizeLimit(2 * 1024)]
    [HttpPost]
    [Route("api/v{version:apiVersion}/process/refund/")]
    public async Task<ActionResult<Segment>> PostTicketRefund(TicketRefundDto ticketRefundDto)
    {
        await _service.PostTicketRefund(ticketRefundDto);
        return Ok();
    }
}