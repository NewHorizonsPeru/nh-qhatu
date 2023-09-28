namespace nh.qhatu.omnichannel.domain.core.entities
{
    public class Product
    {
        public string Id { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryId { get; set; } = null!;
        public string BrandId { get; set; } = null!;
    }
}
