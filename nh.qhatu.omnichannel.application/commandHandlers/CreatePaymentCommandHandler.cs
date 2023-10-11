using MediatR;
using nh.qhatu.domain.bus;
using nh.qhatu.omnichannel.application.commands;
using nh.qhatu.omnichannel.application.events;

namespace nh.qhatu.omnichannel.application.commandHandlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public CreatePaymentCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new CreatePaymentEvent(request.OrderId, request.CustomerId, request.Total));
            return Task.FromResult(true);
        }
    }
}
