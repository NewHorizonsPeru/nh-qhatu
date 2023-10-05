using AutoMapper;
using nh.qhatu.homedelivery.application.dto;
using nh.qhatu.homedelivery.domain.entities;

namespace nh.qhatu.homedelivery.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<HomeDelivery, HomeDeliveryDto>();
        }
    }
}
