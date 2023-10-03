using nh.qhatu.security.application.core.dto;

namespace nh.qhatu.security.application.core.interfaces
{
    public interface ISecurityService
    {
        void SignUp(CreateUserDto userDto);
        UserDto SignIn(string username, string password);
        ICollection<UserDto> GetAllUsers();
    }
}
