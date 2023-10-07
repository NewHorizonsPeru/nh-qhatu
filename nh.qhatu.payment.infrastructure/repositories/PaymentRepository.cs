using nh.qhatu.payment.domain.entities;
using nh.qhatu.payment.domain.interfaces;
using nh.qhatu.payment.infrastructure.context;

namespace nh.qhatu.payment.infrastructure.repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext context) : base(context) { }
    }
}
