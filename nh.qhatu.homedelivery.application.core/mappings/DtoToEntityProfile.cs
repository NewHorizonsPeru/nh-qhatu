using AutoMapper;
using nh.qhatu.homedelivery.application.core.dto;
using nh.qhatu.homedelivery.domain.core.entities;

namespace nh.qhatu.homedelivery.application.core.mappings
{
    public class DtoToEntityProfile : Profile
    {
       public DtoToEntityProfile() 
       {
            CreateMap<HomeDeliveryDto, HomeDelivery>()
                .ForMember(s => s.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
