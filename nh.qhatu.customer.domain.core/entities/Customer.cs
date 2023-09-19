namespace nh.qhatu.customer.domain.core.entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Names { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string IdCardNumber { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; } = null!;
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = null!;
    }
}
