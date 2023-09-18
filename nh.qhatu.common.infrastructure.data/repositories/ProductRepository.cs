using Microsoft.EntityFrameworkCore;
using nh.qhatu.common.domain.core.entities;
using nh.qhatu.common.domain.core.interfaces;
using nh.qhatu.common.infrastructure.data.context;

namespace nh.qhatu.common.infrastructure.data.repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(QhatuContext context) : base(context) { }

        public IEnumerable<Product> ListProductsWithCategoryAndBrand() 
        {
            return _context.Products.Include(x => x.Brand).Include(y => y.Category);
        }
    }
}
