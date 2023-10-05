namespace nh.qhatu.security.domain.core.Entities
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
