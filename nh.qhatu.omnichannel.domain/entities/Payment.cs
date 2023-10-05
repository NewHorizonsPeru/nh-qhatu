namespace nh.qhatu.omnichannel.domain.entities
{
    public partial class Payment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string CustomerId { get; set; } = null!;
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = null!;
    }
}
