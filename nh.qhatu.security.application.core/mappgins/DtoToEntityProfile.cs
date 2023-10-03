using AutoMapper;
using nh.qhatu.security.application.core.dto;
using nh.qhatu.security.domain.core.Entities;

namespace nh.qhatu.security.application.core.mappgins
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
