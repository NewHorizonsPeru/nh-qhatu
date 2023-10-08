using AutoMapper;
using nh.qhatu.payment.application.dto;
using nh.qhatu.payment.domain.entities;

namespace nh.qhatu.payment.application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Payment, PaymentDto>();
        }
    }
}
