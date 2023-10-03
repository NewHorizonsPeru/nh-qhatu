using nh.qhatu.security.domain.core.Entities;
using nh.qhatu.security.domain.core.Interfaces;
using nh.qhatu.security.infrastructure.data.Context;

namespace nh.qhatu.security.infrastructure.data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SecurityContext context) : base(context) { }
    }
}
