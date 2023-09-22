using AutoMapper;
using nh.qhatu.omnichannel.application.core.dto;
using nh.qhatu.omnichannel.domain.core.entities;

namespace nh.qhatu.omnichannel.application.core.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Payment, PaymentDto>();
        }
    }
}
