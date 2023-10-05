namespace nh.qhatu.security.application.core.dto
{
    public class SignInResponseDto : UserDto
    {
        public string Token { get; set; } = null!;
    }
}
