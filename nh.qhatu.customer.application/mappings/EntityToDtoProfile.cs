using AutoMapper;
using nh.qhatu.customer.application.dto;
using nh.qhatu.customer.domain.entities;

namespace nh.qhatu.customer.application.mappings
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
