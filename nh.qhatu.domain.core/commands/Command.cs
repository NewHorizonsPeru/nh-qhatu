using nh.qhatu.domain.events;

namespace nh.qhatu.domain.commands
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
