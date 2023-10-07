using nh.qhatu.domain.bus;
using nh.qhatu.domain.commands;
using nh.qhatu.domain.events;

namespace nh.qhatu.domain.bus
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
