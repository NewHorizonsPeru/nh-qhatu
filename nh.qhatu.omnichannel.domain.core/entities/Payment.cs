namespace nh.qhatu.omnichannel.domain.core.entities
{
    public partial class Payment
    {
        public string Id { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = null!;
    }
}
