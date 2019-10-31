using Newtonsoft.Json;

namespace LineDC.Pay.Models
{
    /// <summary>
    /// Payment Reserve Response
    /// </summary>
    public class ReserveResponse : ResponseBase
    {
        /// <summary>
        /// Reserve Information
        /// </summary>
        [JsonProperty("info")]
        public ReserveInfo Info { get; set; }
    }
}
