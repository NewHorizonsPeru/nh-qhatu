using AutoMapper;
using nh.qhatu.omnichannel.application.core.dto;
using nh.qhatu.omnichannel.application.core.interfaces;
using nh.qhatu.omnichannel.domain.core.interfaces;

namespace nh.qhatu.omnichannel.application.core.services
{
    public class OrderrService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderrService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public ICollection<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllWithDetail();
            var ordersDto = _mapper.Map<ICollection<OrderDto>>(orders);
            return ordersDto;
        }
    }
}
