namespace nh.qhatu.customer.domain.core.entities
{
    public partial class Customer
    {
        public string Id { get; set; } = null!;
        public string Names { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string IdCardNumber { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = null!;
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = null!;
    }
}
