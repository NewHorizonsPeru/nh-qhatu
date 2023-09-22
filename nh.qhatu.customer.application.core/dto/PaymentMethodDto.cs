namespace nh.qhatu.customer.application.core.dto
{
    public partial class PaymentMethodDto
    {
        public string Id { get; set; } = null!;
        public string CreditCardNumber { get; set; } = null!;
        public string CreditCardTypeId { get; set; } = null!;
        public string ExpirationDate { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public int Active { get; set; }
    }
}
