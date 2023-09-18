using MediatR;

namespace nh.qhatu.domain.core.events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message() 
        {
            MessageType = GetType().Name;
        }
    }
}
