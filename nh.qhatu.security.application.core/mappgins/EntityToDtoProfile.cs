using AutoMapper;
using nh.qhatu.security.application.core.dto;
using nh.qhatu.security.domain.core.Entities;

namespace nh.qhatu.security.application.core.mappgins
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
