﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LineDC.Pay.Models
{
    /// <summary>
    /// Transaction types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionType
    {
        PAYMENT, // Payment
        PAYMENT_REFUND, // Refund
        PARTIAL_REFUND // Partion refund
    }
}
