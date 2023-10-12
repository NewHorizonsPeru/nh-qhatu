using MassTransit;
using nh.qhatu.infrasctructure.crosscutting;
using nh.qhatu.payment.application.dto.Creates;
using nh.qhatu.payment.application.interfaces;

namespace nh.qhatu.payment.application.eventHandlers
{
    public class CreatePaymentEventHandler : IConsumer<CreatePaymentEvent>
    {
        private readonly IPaymentService _paymentService;

        public CreatePaymentEventHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Task Consume(ConsumeContext<CreatePaymentEvent> context)
        {
            var paymentDto = new CreatePaymentDto
            {
                OrderId = context.Message.OrderId,
                CustomerId = context.Message.CustomerId,
                Total = context.Message.Total,
            };

            var successPayment = _paymentService.CreatePayment(paymentDto);

            return Task.CompletedTask;
        }
    }
}
