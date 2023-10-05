using nh.qhatu.omnichannel.domain.entities;

namespace nh.qhatu.omnichannel.domain.interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetAllWithDetail();
    }
}
