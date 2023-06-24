using TicketsAPI.Validation.DtoValidation;
using TicketsAPI.Validation.JsonValidation;

namespace TicketsAPI.DTO;

[JsonRefund]
public class TicketRefundDto
{
    public string operation_type { get; set; }
    public string operation_time { get; set; }
    public string operation_place { get; set; }
    [TicketNumberValidation]
    public string ticket_number { get; set; }
}