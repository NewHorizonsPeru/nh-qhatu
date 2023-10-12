namespace nh.qhatu.omnichannel.application.dto.creates
{
    public class CreateOrderDto
    {
        public string CustomerId { get; set; } = null!;
        public int State { get; set; } 
        public decimal Total { get; set; }

        public virtual ICollection<CreateOrderDetailDto> OrderDetails { get; set; } = null!;
    }

    public class CreateOrderDetailDto
    {
        public string ProductId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
