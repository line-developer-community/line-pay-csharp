﻿using Newtonsoft.Json;

namespace LineDC.Pay.Models
{
    /// <summary>
    /// Refund
    /// </summary>
    public class Refund
    {
        [JsonProperty("refundAmount")]
        public int RefundAmount { get; set; }
    }
}
