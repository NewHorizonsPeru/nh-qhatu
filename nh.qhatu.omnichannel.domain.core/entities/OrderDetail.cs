namespace nh.qhatu.omnichannel.domain.core.entities
{
    public partial class OrderDetail
    {
        public string Id { get; set; } = null!;
        public string OrderId { get; set; } = string.Empty;
        public string ProductId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
