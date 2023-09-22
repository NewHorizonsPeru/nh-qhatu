namespace nh.qhatu.customer.domain.core.entities
{
    public partial class Address
    {
        public string Id { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string CustomerId { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
