namespace nh.qhatu.homedelivery.domain.core.entities
{
    public partial class HomeDelivery
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; } = null!;
        public int Departament { get; set; }
        public int Province { get; set; }
        public int District { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
