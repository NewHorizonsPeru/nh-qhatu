using AutoMapper;
using nh.qhatu.crosscutting.Bcrypt;
using nh.qhatu.security.application.core.dto;
using nh.qhatu.security.application.core.interfaces;
using nh.qhatu.security.domain.core.Entities;
using nh.qhatu.security.domain.core.Interfaces;

namespace nh.qhatu.security.application.core.services
{
    public class SecurityService : ISecurityService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        

        public SecurityService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public ICollection<UserDto> GetAllUsers()
        {
            var users = _userRepository.List();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public UserDto SignIn(string username, string password)
        {
            throw new NotImplementedException();
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
