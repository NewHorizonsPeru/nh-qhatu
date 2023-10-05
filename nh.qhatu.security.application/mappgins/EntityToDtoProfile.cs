using AutoMapper;
using nh.qhatu.security.application.dto;
using nh.qhatu.security.domain.entities;

namespace nh.qhatu.security.application.mappgins
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, SignInResponseDto>();
        }
    }
}
