namespace nh.qhatu.common.application.core.dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public BrandDto Brand { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
    }
}
