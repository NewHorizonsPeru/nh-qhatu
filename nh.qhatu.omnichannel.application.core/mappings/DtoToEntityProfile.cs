using AutoMapper;
using nh.qhatu.omnichannel.application.core.dto;
using nh.qhatu.omnichannel.domain.core.entities;

namespace nh.qhatu.omnichannel.application.core.mappings
{
    public class DtoToEntityProfile : Profile
    {
       public DtoToEntityProfile() 
       {
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<OrderDto, OrderDto>();
            CreateMap<PaymentDto, Payment>();
        }
    }
}
