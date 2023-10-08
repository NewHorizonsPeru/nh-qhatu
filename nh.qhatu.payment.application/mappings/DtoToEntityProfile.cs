using AutoMapper;
using nh.qhatu.payment.application.dto;
using nh.qhatu.payment.application.dto.Creates;
using nh.qhatu.payment.domain.entities;

namespace nh.qhatu.payment.application.mappings
{
    public class DtoToEntityProfile : Profile
    {
       public DtoToEntityProfile() 
       {
            CreateMap<PaymentDto, Payment>();
            CreateMap<CreatePaymentDto, Payment>();
        }
    }
}
