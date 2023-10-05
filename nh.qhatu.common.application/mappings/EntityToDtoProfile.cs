using AutoMapper;
using nh.qhatu.common.application.dto;
using nh.qhatu.common.domain.entities;

namespace nh.qhatu.common.application.mappings
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
