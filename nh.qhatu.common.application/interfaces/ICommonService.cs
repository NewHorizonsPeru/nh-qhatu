using nh.qhatu.common.application.dto;

namespace nh.qhatu.common.application.interfaces
{
    public interface ICommonService
    {
        IEnumerable<BrandDto> GetAllBrands();
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto ValidateProductExistence(string productId);
    }
}
