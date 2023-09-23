using nh.qhatu.omnichannel.application.core.dto;
using nh.qhatu.omnichannel.application.core.dto.Creates;

namespace nh.qhatu.omnichannel.application.core.interfaces
{
    public interface IOrderService
    {
        ICollection<OrderDto> GetAllOrders();
        void CreateOrder(CreateOrderDto orderDto);
    }
}
