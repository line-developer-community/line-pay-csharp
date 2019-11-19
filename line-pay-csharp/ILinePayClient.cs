using System.Threading.Tasks;
using LineDC.Pay.Models;

namespace LineDC.Pay
{
    public interface ILinePayClient
    {
        Task<CaptureResponse> CaptureAsync(long transactionId, Capture capture);
        Task<CaptureResponse> CaptureAsync(long transactionId, int amount, Currency currency);
        Task<ConfirmResponse> ConfirmAsync(long transactionId, Confirm confirm);
        Task<ConfirmResponse> ConfirmAsync(long transactionId, int amount, Currency currency);
        Task<AuthorizationResponse> GetAuthorizationAsync(long? transactionId, string orderId);
        Task<PaymentResponse> GetPaymentAsync(long? transactionId, string orderId = null);
        Task<PreApprovedPayResponse> PreApprovedPayAsync(string regKey, PreApprovedPay preApprovedPay);
        Task<RefundResponse> RefundAsync(long transactionId, int refundAmount);
        Task<RefundResponse> RefundAsync(long transactionId, Refund refund);
        Task<ResponseBase> RegKeyCheckAsync(string regKey, bool creditCardAuth = false);
        Task<ResponseBase> RegKeyExpireAsync(string regKey);
        Task<ReserveResponse> ReserveAsync(Reserve reserve);
        Task<ResponseBase> VoidAuthorizationAsync(long transactionId);
    }
}