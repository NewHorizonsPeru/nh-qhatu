using AutoMapper;
using nh.qhatu.omnichannel.application.core.dto;
using nh.qhatu.omnichannel.application.core.dto.Creates;
using nh.qhatu.omnichannel.application.core.interfaces;
using nh.qhatu.omnichannel.domain.core.entities;
using nh.qhatu.omnichannel.domain.core.interfaces;

namespace nh.qhatu.omnichannel.application.core.services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
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

        public void CreateOrder(CreateOrderDto orderDto) 
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderRepository.Add(order);
            _orderRepository.Save();
        }
    }
}
