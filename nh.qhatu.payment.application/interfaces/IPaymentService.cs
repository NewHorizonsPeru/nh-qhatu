using nh.qhatu.payment.application.dto.Creates;

namespace nh.qhatu.payment.application.interfaces
{
    public interface IPaymentService
    {
        bool CreatePayment(CreatePaymentDto createPaymentDto);
    }
}
