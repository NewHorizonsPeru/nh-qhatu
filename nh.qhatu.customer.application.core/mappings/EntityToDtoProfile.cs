using AutoMapper;
using nh.qhatu.customer.application.core.dto;
using nh.qhatu.customer.domain.core.entities;

namespace nh.qhatu.customer.application.core.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Address, AddressDto>();
            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
