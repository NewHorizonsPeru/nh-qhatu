using AutoMapper;
using nh.qhatu.payment.application.dto.Creates;
using nh.qhatu.payment.application.interfaces;
using nh.qhatu.payment.domain.entities;
using nh.qhatu.payment.domain.interfaces;

namespace nh.qhatu.payment.application.services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository) 
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public bool CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var payment = _mapper.Map<Payment>(createPaymentDto);
            _paymentRepository.Add(payment);
            return _paymentRepository.Save();
        }
    }
}
