namespace nh.qhatu.payment.application.dto.Creates
{
    public class CreatePaymentDto
    {
        public string CustomerId { get; set; } = null!;
        public decimal Total { get; set; }
    }
}
