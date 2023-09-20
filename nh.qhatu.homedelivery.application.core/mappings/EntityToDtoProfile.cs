using AutoMapper;
using nh.qhatu.homedelivery.application.core.dto;
using nh.qhatu.homedelivery.domain.core.entities;

namespace nh.qhatu.homedelivery.application.core.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<HomeDelivery, HomeDeliveryDto>();
        }
    }
}
