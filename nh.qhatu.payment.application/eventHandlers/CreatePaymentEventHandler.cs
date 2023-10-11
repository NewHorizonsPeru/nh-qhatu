using nh.qhatu.domain.bus;
using nh.qhatu.payment.application.dto.Creates;
using nh.qhatu.payment.application.events;
using nh.qhatu.payment.application.interfaces;

namespace nh.qhatu.payment.application.eventHandlers
{
    public class CreatePaymentEventHandler : IEventHandler<CreatePaymentEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly IPaymentService _paymentService;

        public CreatePaymentEventHandler(IEventBus eventBus, IPaymentService paymentService) 
        {
            _eventBus = eventBus;
            _paymentService = paymentService;
        }
        
        public Task Handle(CreatePaymentEvent @event)
        {
            var paymentDto = new CreatePaymentDto
            {
                OrderId = @event.OrderId,
                CustomerId = @event.CustomerId,
                Total = @event.Total,
            };

            var successPayment = _paymentService.CreatePayment(paymentDto);

            return Task.CompletedTask;
        }
    }
}
