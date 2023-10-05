using nh.qhatu.security.application.core.dto;

namespace nh.qhatu.security.application.core.interfaces
{
    public interface ISecurityService
    {
        void SignUp(CreateUserDto userDto);
        SignInResponseDto SignIn(SignInRequestDto signInRequestDto);
        ICollection<UserDto> GetAllUsers();
    }
}
