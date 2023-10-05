using nh.qhatu.common.domain.entities;
using nh.qhatu.common.domain.interfaces;
using nh.qhatu.common.infrastructure.context;

namespace nh.qhatu.common.infrastructure.repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(CommonContext context) : base(context) { }
    }
}
