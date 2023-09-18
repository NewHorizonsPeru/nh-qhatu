namespace nh.qhatu.domain.core.events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event() 
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
