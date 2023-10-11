using nh.qhatu.domain.events;

namespace nh.qhatu.omnichannel.application.events
{
    public class CreatePaymentEvent : Event
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public decimal Total { get;set; }

        public CreatePaymentEvent(string orderId, string customerId, decimal total)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Total = total;
        }
    }
}
