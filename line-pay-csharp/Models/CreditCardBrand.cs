using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LineDC.Pay.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CreditCardBrand
    {
        VISA,
        MASTER,
        AMEX,
        DINERS,
        JCB
    }
}
