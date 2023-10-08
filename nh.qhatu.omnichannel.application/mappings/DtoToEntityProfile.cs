using AutoMapper;
using nh.qhatu.omnichannel.application.dto;
using nh.qhatu.omnichannel.application.dto.Creates;
using nh.qhatu.omnichannel.domain.entities;

namespace nh.qhatu.omnichannel.application.mappings
{
    public class DtoToEntityProfile : Profile
    {
       public DtoToEntityProfile() 
       {
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderDto, Order>();

            CreateMap<CreateOrderDetailDto, OrderDetail>();
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
