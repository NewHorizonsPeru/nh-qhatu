using nh.qhatu.domain.core.events;

namespace nh.qhatu.domain.core.bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler { }
}
