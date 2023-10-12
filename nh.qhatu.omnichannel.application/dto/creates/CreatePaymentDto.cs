namespace nh.qhatu.omnichannel.application.dto.creates
{
    public class CreatePaymentDto
    {
        public string OrderId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public decimal Total { get; set; }
    }
}
