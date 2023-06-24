using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Validation.DtoValidation;

public class DocTypeValidation: ValidationAttribute
{
    public static int doc_type = 1;
    public override bool IsValid(object value)
    {
        
        if (value.ToString() == "00")
        {
            doc_type = 0;
        }

        return true;
    }
}