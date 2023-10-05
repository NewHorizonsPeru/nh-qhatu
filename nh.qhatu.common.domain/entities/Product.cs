using System;
using System.Collections.Generic;

namespace nh.qhatu.common.domain.entities
{
    public partial class Product
    {
        public string Id { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
        public string BrandId { get; set; } = null!;

        public virtual Brand Brand { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
