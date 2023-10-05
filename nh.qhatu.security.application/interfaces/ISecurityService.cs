using nh.qhatu.security.application.dto;

namespace nh.qhatu.security.application.interfaces
{
    public interface ISecurityService
    {
        void SignUp(CreateUserDto userDto);
        SignInResponseDto SignIn(SignInRequestDto signInRequestDto);
        ICollection<UserDto> GetAllUsers();
    }
}
