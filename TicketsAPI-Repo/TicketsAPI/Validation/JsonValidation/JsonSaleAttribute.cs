using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using TicketsAPI.DTO;

namespace TicketsAPI.Validation.JsonValidation;

public class JsonSaleAttribute :  ValidationAttribute
{
    public override bool IsValid (object value)
    {
        JSchemaGenerator generator = new JSchemaGenerator();
        JSchema schema = generator.Generate(typeof(TicketSaleDto));
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        JObject jObject = JObject.Parse(json);
        if (jObject.IsValid(schema))
        {
        }
        else
        {
            throw new BadHttpRequestException("400");  
        }

        return true;

    }
}