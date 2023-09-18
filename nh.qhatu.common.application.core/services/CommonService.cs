using AutoMapper;
using nh.qhatu.common.application.core.dto;
using nh.qhatu.common.application.core.interfaces;
using nh.qhatu.common.domain.core.interfaces;

namespace nh.qhatu.common.application.core.services
{
    public class CommonService : ICommonService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;

        public CommonService(IBrandRepository brandRepository, IProductRepository productRepository ,IMapper mapper) 
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<BrandDto> GetAllBrands()
        {
            var brands = _brandRepository.List();
            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandsDto;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productRepository.ListProductsWithCategoryAndBrand();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }
    }
}
