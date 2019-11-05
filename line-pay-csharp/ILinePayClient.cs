using LineDC.Pay.Models;
using System;
using System.Threading.Tasks;

namespace LineDC.Pay
{
    public interface ILinePayClient : IDisposable
    {
        #region Message 

        /// <summary>
        /// Get Payment Details AP
        /// Gets the details of payments made with LINE Pay. This API only gets the payments that have been captured.
        /// </summary>
        /// <param name="transactionId">A transaction ID issued by LINE Pay, for payment or refund.</param>
        /// <param name="orderId">Merchant Transaction Order ID</param>
        /// <returns>PaymentResponse</returns>
        Task<PaymentResponse> GetPaymentAsync(Int64? transactionId, string orderId = null);

        /// <summary>
        /// Reserve Payment API
        /// Prior to processing payments with LINE Pay, the Merchant is evaluated if it is a normal Merchant store then the
        /// information is reserved for payment.When a payment is successfully reserved, the Merchant gets a "transactionId"
        /// that is a key value used until the payment is completed or refunded.
        /// </summary>
        /// <param name="reserve">Reserve Information</param>
        /// <returns>ReserveResponse</returns>
        Task<ReserveResponse> ReserveAsync(Reserve reserve);

        /// <summary>
        /// Payment Confirm API
        /// This API is used for a Merchant to complete its payment. The Merchant must call Confirm Payment API to
        /// actually complete the payment.However, when "capture" parameter is "false" on payment reservation, the
        /// payment status becomes AUTHORIZATION, and the payment is completed only after "Capture API" is called.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <param name="amount">Payment amount</param>
        /// <param name="currency">Payment currency (ISO 4217)</param>
        /// <returns>ConfirmResponse</returns>
        Task<ConfirmResponse> ConfirmAsync(Int64 transactionId, int amount, Currency currency);

        /// <summary>
        /// Payment Confirm API
        /// This API is used for a Merchant to complete its payment. The Merchant must call Confirm Payment API to
        /// actually complete the payment.However, when "capture" parameter is "false" on payment reservation, the
        /// payment status becomes AUTHORIZATION, and the payment is completed only after "Capture API" is called.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <param name="confirm">Confirm</param>
        /// <returns>ConfirmResponse</returns>
        Task<ConfirmResponse> ConfirmAsync(Int64 transactionId, Confirm confirm);

        /// <summary>
        /// Refund Payment API
        /// Requests refund of payments made with LINE Pay. To refund a payment, the LINE Pay user's payment transaction
        /// Id must be forwarded.A partial refund is also possible depending on the refund amount.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <param name="refundAmount">Refund Amount</param>
        /// <returns>RefundResponse</returns>
        Task<RefundResponse> RefundAsync(Int64 transactionId, int refundAmount);
        
        /// <summary>
        /// Refund Payment API
        /// Requests refund of payments made with LINE Pay. To refund a payment, the LINE Pay user's payment transaction
        /// Id must be forwarded.A partial refund is also possible depending on the refund amount.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <param name="refund">Refund</param>
        /// <returns>RefundResponse</returns>
        Task<RefundResponse> RefundAsync(Int64 transactionId, Refund refund);

        /// <summary>
        /// Get Authorization Details API
        /// Gets the details authorized with LINE Pay. This API only gets data that is authorized or whose authorization is voided; 
        /// the one that is already captured can be viewed by using "Get Payment Details API”. 
        /// </summary>
        /// <param name="transactionId">Transaction number issued by LINE Pay</param>
        /// <param name="orderId">Order number of Merchant</param>
        /// <returns>AuthorizationResponse</returns>
        Task<AuthorizationResponse> GetAuthorizationAsync(Int64? transactionId, string orderId);

        /// <summary>
        /// Capture API
        /// If "capture" is "false" when the Merchant calls the “Reserve Payment API” , the payment is completed only after the Capture API is called.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <param name="amount">Payment amount</param>
        /// <param name="currency">Payment currency </param>
        /// <returns>CaptureResponse</returns>
        Task<CaptureResponse> CaptureAsync(Int64 transactionId, int amount, Currency currency);
        
        /// <summary>
        /// Capture API
        /// If "capture" is "false" when the Merchant calls the “Reserve Payment API” , the payment is completed only after the Capture API is called.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <param name="capture">Capture</param>
        /// <returns>CaptureResponse</returns>
        Task<CaptureResponse> CaptureAsync(Int64 transactionId, Capture capture);

        /// <summary>
        /// Void Authorization API
        /// Voids a previously authorized payment. A payment that has been already captured can be refunded by using the "Refund Payment API”
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns></returns>
        Task<ResponseBase> VoidAuthorizationAsync(Int64 transactionId);

        /// <summary>
        /// Preapproved Payment API
        /// When the payment type of the Reserve Payment API was set as PREAPPROVED, a regKey is returned with the
        /// payment result.Preapproved Payment API uses this regKey to directly complete a payment without using the LINE app.
        /// </summary>
        /// <param name="regKey">Registration Key</param>
        /// <param name="preApprovedPay">PreApprovedPay</param>
        /// <returns></returns>
        Task<PreApprovedPayResponse> PreApprovedPayAsync(string regKey, PreApprovedPay preApprovedPay);

        /// <summary>
        /// Check regKey Status API
        /// Checks if regKey is available before using the preapproved payment API
        /// </summary>
        /// <param name="regKey">Registration Key</param>
        /// <param name="creditCardAuth">Check Authorization for Credit Card minimum amount saved in regKey</param>
        /// <returns></returns>
        Task<ResponseBase> RegKeyCheckAsync(string regKey, bool creditCardAuth = false);

        /// <summary>
        /// Expire regKey API
        /// Expires the regKey information registered for preapproved payment.Once the API is called, the regKey is no longer used for preapproved payments.
        /// </summary>
        /// <param name="regKey">Registration Key</param>
        /// <returns></returns>
        Task<ResponseBase> RegKeyExpireAsync(string regKey);
        #endregion
    }
}
