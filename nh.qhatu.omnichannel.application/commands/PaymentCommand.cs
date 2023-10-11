using nh.qhatu.domain.commands;

namespace nh.qhatu.omnichannel.application.commands
{
    public class PaymentCommand : Command
    {
        public string OrderId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public decimal Total { get; set; }
    }
}
