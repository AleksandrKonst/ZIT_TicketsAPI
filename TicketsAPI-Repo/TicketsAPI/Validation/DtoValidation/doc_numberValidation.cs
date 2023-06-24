using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Validation.DtoValidation;

public class DocNumberValidation: ValidationAttribute
{
    
    public override bool IsValid (object value)
    {
        if (value.ToString().Length == 10 && DocTypeValidation.doc_type == 0)
        {
        }
        else
        {
            throw new BadHttpRequestException("400");
        }
        return true;
    }
}