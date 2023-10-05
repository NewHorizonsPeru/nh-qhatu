using nh.qhatu.common.domain.entities;

namespace nh.qhatu.common.domain.interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> ListProductsWithCategoryAndBrand();
    }
}
