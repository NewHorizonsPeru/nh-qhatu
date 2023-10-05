namespace nh.qhatu.omnichannel.application.dto
{
    public class OrderDetailDto
    {
        public string OrderId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string Id { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
