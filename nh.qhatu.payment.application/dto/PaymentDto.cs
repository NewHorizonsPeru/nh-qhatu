namespace nh.qhatu.payment.application.dto
{
    public class PaymentDto
    {
        public string Id { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string OrderId { get; set; } = null!;
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
