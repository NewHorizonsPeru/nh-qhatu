using nh.qhatu.omnichannel.domain.entities;

namespace nh.qhatu.omnichannel.domain.interfaces
{
    public interface IProductRepository
    {
        Task<Product> ValidateProductExistence(string  productId);
    }
}
