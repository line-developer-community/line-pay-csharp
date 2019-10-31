using Newtonsoft.Json;

namespace LineDC.Pay.Models
{
    /// <summary>
    /// Get Authorization Details Response
    /// </summary>
    public class AuthorizationResponse : ResponseBase
    {
        [JsonProperty("info")]
        public AuthorizationInfo[] Info { get; set; }
    }
}
