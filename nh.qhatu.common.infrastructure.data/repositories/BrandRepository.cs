using nh.qhatu.common.domain.core.entities;
using nh.qhatu.common.domain.core.interfaces;
using nh.qhatu.common.infrastructure.data.context;

namespace nh.qhatu.common.infrastructure.data.repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(QhatuContext context) : base(context) { }
    }
}
