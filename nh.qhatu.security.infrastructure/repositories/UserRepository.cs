using nh.qhatu.security.domain.entities;
using nh.qhatu.security.domain.interfaces;
using nh.qhatu.security.infrastructure.context;

namespace nh.qhatu.security.infrastructure.repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context) { }
    }
}
