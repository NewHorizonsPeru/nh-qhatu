namespace nh.qhatu.customer.application.dto
{
    public partial class CustomerDto
    {
        public string Id { get; set; } = null!;
        public string Names { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string IdCardNumber { get; set; } = null!;

        public ICollection<AddressDto> Addresses { get; set; } = null!;
        public ICollection<PaymentMethodDto> PaymentMethods { get; set; } = null!;
    }
}
