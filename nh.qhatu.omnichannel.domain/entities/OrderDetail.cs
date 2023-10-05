namespace nh.qhatu.omnichannel.domain.entities
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
