using Newtonsoft.Json;

namespace LineDC.Pay.Models
{
    /// <summary>
    /// Refund Payment Response
    /// </summary>
    public class RefundResponse : ResponseBase
    {
        /// <summary>
        /// Refund Information
        /// </summary>
        [JsonProperty("info")]
        public RefundInfo Info { get; set; }
    }
}
