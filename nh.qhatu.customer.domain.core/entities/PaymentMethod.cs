namespace nh.qhatu.customer.domain.core.entities
{
    public partial class PaymentMethod
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; } = null!;
        public int CreditCardTypeId { get; set; }
        public string ExpirationDate { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int CustomerId { get; set; }
        public int Active { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
