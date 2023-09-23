namespace nh.qhatu.omnichannel.domain.core.entities
{
    public partial class Order
    {
        public Order() 
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; set; }
        public string CustomerId { get; set; } = null!;
        public string PaymentId { get; set; } = null!;
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }

        public virtual Payment Payment { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
