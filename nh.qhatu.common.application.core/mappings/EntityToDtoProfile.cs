using AutoMapper;
using nh.qhatu.common.application.core.dto;
using nh.qhatu.common.domain.core.entities;

namespace nh.qhatu.common.application.core.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Brand, BrandDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<CreditCardType, CreditCardTypeDto>();
        }
    }
}
