using nh.qhatu.common.domain.core.entities;

namespace nh.qhatu.common.domain.core.interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> ListProductsWithCategoryAndBrand();
    }
}
