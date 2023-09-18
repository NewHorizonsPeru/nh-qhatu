using nh.qhatu.domain.core.bus;
using nh.qhatu.domain.core.commands;
using nh.qhatu.domain.core.events;

namespace nh.micro.qhatu.domain.core.bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
