using AutoMapper;
using nh.qhatu.omnichannel.application.dto;
using nh.qhatu.omnichannel.domain.entities;

namespace nh.qhatu.omnichannel.application.mappings
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
