using nh.qhatu.payment.application.dto.Creates;

namespace nh.qhatu.payment.application.interfaces
{
    public interface IPaymentService
    {
        void CreatePayment(CreatePaymentDto createPaymentDto);
    }
}
