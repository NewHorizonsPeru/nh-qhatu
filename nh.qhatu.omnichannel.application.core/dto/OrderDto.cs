namespace nh.qhatu.omnichannel.application.core.dto
{
    public class OrderDto
    {
        public string Id { get; set; } = null;
        public string CustomerId { get; set; } = null!;
        public string PaymentId { get; set; } = null!;
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; } = null!;
    }
}
