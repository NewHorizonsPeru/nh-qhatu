using nh.qhatu.omnichannel.domain.core.entities;

namespace nh.qhatu.omnichannel.domain.core.interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetAllWithDetail();
    }
}
