using nh.qhatu.common.domain.core.entities;
using nh.qhatu.common.domain.core.interfaces;
using nh.qhatu.common.infrastructure.data.context;

namespace nh.qhatu.common.infrastructure.data.repositories
{
    public class CreditCardTypeRepository : GenericRepository<CreditCardType>, ICreditCardTypeRepository
    {
        public CreditCardTypeRepository(QhatuContext context) : base(context) { }
    }
}
