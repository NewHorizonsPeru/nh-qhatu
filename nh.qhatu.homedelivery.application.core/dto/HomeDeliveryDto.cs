namespace nh.qhatu.homedelivery.application.core.dto
{
    public partial class HomeDeliveryDto
    {
        public string Id { get; set; } = null!;
        public string OrderId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string AddressId { get; set; } = null!;
        public int State { get; set; }
    }
}
