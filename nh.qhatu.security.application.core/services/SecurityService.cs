using AutoMapper;
using nh.qhatu.infrasctructure.crosscutting.Bcrypt;
using nh.qhatu.infrasctructure.crosscutting.Jwt;
using nh.qhatu.security.application.core.dto;
using nh.qhatu.security.application.core.interfaces;
using nh.qhatu.security.domain.core.Entities;
using nh.qhatu.security.domain.core.Interfaces;

namespace nh.qhatu.security.application.core.services
{
    public class SecurityService : ISecurityService
    {
        private readonly IMapper _mapper;
        private readonly IJwtManager _jwtManager;
        private readonly IUserRepository _userRepository;
        

        public SecurityService(IMapper mapper, IJwtManager jwtManager, IUserRepository userRepository)
        {
            _mapper = mapper;
            _jwtManager = jwtManager;
            _userRepository = userRepository;
        }

        public ICollection<UserDto> GetAllUsers()
        {
            var users = _userRepository.List();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public SignInResponseDto SignIn(SignInRequestDto signInRequestDto)
        {
            var currentUser = _userRepository.Find(s => s.Username.Equals(signInRequestDto.Username)).FirstOrDefault();
            if (currentUser == null || !BCryptManager.Verify(signInRequestDto.Password, currentUser.Password)) return null;
            var signInResponseDto = _mapper.Map<SignInResponseDto>(currentUser);
            signInResponseDto.Token = _jwtManager.GenerateToken(signInResponseDto.Id, signInResponseDto.Username, signInResponseDto.CustomerId);
            return signInResponseDto;
        }

        public void SignUp(CreateUserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                user.Password = BCryptManager.HashText(user.Password);
                _userRepository.Add(user);
                _userRepository.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
