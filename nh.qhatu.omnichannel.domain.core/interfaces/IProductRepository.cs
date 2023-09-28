using nh.qhatu.omnichannel.domain.core.entities;

namespace nh.qhatu.omnichannel.domain.core.interfaces
{
    public interface IProductRepository
    {
        Task<Product> ValidateProductExistence(string  productId);
    }
}
