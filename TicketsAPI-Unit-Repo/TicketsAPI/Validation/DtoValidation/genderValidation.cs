using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Validation.DtoValidation;

public class GenderValidation : ValidationAttribute
{
    public override bool IsValid (object value)
    {
        if (value.ToString() != "M" && value.ToString() != "F" )
        {
            throw new BadHttpRequestException("400");
        }
        return true;
    }
}