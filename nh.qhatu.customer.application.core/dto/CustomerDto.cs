namespace nh.qhatu.customer.application.core.dto
{
    public partial class CustomerDto
    {
        public int Id { get; set; }
        public string Names { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string IdCardNumber { get; set; } = null!;

        public ICollection<AddressDto> Addresses { get; set; } = null!;
        public ICollection<PaymentMethodDto> PaymentMethods { get; set; } = null!;
    }
}
