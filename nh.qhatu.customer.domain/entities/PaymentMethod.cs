namespace nh.qhatu.customer.domain.entities
{
    public partial class PaymentMethod
    {
        public string Id { get; set; } = null!;
        public string CreditCardNumber { get; set; } = null!;
        public string CreditCardTypeId { get; set; } = null!;
        public string ExpirationDate { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string CustomerId { get; set; } = null!;
        public int Active { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
