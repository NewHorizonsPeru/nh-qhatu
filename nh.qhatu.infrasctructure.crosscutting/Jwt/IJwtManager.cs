namespace nh.qhatu.infrasctructure.crosscutting.Jwt
{
    public interface IJwtManager
    {
        string GenerateToken(string userId, string username, string customerId);
    }
}
