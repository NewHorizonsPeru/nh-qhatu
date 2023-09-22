using nh.qhatu.omnichannel.application.core.dto;

namespace nh.qhatu.omnichannel.application.core.interfaces
{
    public interface IOrderService
    {
        ICollection<OrderDto> GetAllOrders();
    }
}
