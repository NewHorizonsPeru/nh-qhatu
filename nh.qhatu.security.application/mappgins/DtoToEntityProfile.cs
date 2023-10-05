using AutoMapper;
using nh.qhatu.security.application.dto;
using nh.qhatu.security.domain.entities;

namespace nh.qhatu.security.application.mappgins
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
