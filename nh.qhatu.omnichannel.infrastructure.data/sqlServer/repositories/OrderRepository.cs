using Microsoft.EntityFrameworkCore;
using nh.qhatu.omnichannel.domain.core.entities;
using nh.qhatu.omnichannel.domain.core.interfaces;
using nh.qhatu.omnichannel.infrastructure.data.sqlServer.context;

namespace nh.qhatu.omnichannel.infrastructure.data.sqlServer.repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(QhatuContext context) : base(context) { }

        public IEnumerable<Order> GetAllWithDetail()
        {
            return _context.Order.Include(i => i.OrderDetails);
        }
    }
}
