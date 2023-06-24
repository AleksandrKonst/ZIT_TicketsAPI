using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Validation.DtoValidation;

public class TicketNumberValidation : ValidationAttribute
{
    public override bool IsValid (object value)
    {
        if (value.ToString().Length != 13)
        {
            throw new BadHttpRequestException("400");
        }
        return true;
    }
}