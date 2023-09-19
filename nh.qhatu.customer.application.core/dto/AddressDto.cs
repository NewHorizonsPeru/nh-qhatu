namespace nh.qhatu.customer.application.core.dto
{
    public partial class AddressDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CustomerId { get; set; } 
    }
}
