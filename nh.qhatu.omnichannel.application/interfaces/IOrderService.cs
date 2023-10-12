using nh.qhatu.omnichannel.application.dto;
using nh.qhatu.omnichannel.application.dto.creates;

namespace nh.qhatu.omnichannel.application.interfaces
{
    public interface IOrderService
    {
        ICollection<OrderDto> GetAllOrders();
        Task<bool> CreateOrder(CreateOrderDto orderDto);
    }
}
