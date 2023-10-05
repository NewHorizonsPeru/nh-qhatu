namespace nh.qhatu.homedelivery.domain.entities
{

    public class HomeDelivery
    {
        public string Id { get; set; } = null!;
        public string OrderId { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string AddressId { get; set; } = null!;
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
