using nh.qhatu.common.domain.entities;
using nh.qhatu.common.domain.interfaces;
using nh.qhatu.common.infrastructure.context;

namespace nh.qhatu.common.infrastructure.repositories
{
    public class CreditCardTypeRepository : GenericRepository<CreditCardType>, ICreditCardTypeRepository
    {
        public CreditCardTypeRepository(CommonContext context) : base(context) { }
    }
}
