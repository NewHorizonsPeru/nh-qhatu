using AutoMapper;
using nh.qhatu.homedelivery.application.dto;
using nh.qhatu.homedelivery.domain.entities;

namespace nh.qhatu.homedelivery.application.mappings
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
