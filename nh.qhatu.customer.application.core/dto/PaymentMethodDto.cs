namespace nh.qhatu.customer.application.core.dto
{
    public partial class PaymentMethodDto
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; } = null!;
        public int CreditCardTypeId { get; set; }
        public string ExpirationDate { get; set; } = null!;
        public int CustomerId { get; set; }
        public int Active { get; set; }
    }
}
