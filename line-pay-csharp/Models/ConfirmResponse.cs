using Newtonsoft.Json;

namespace LineDC.Pay.Models
{
    /// <summary>
    /// Payment ConfirmAPI Response
    /// </summary>
    public class ConfirmResponse : ResponseBase
    {
        [JsonProperty("info")]
        public ConfirmInfo Info { get; set; }
    }
}
