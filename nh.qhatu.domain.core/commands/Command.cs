using nh.qhatu.domain.core.events;

namespace nh.qhatu.domain.core.commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command() 
        {
            Timestamp = DateTime.Now;
        }
    }
}
