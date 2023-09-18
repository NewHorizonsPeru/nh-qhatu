using nh.qhatu.common.application.core.dto;

namespace nh.qhatu.common.application.core.interfaces
{
    public interface ICommonService
    {
        IEnumerable<BrandDto> GetAllBrands();

        IEnumerable<ProductDto> GetAllProducts();
    }
}
