using AutoMapper;
using nh.qhatu.domain.bus;
using nh.qhatu.omnichannel.application.commands;
using nh.qhatu.omnichannel.application.dto;
using nh.qhatu.omnichannel.application.dto.Creates;
using nh.qhatu.omnichannel.application.interfaces;
using nh.qhatu.omnichannel.domain.entities;
using nh.qhatu.omnichannel.domain.interfaces;

namespace nh.qhatu.omnichannel.application.services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IEventBus eventBus, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _eventBus = eventBus;
            _orderRepository = orderRepository;
        }

        public ICollection<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllWithDetail();
            var ordersDto = _mapper.Map<ICollection<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task<bool> CreateOrder(CreateOrderDto orderDto) 
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderRepository.Add(order);

            var successRegister = _orderRepository.Save();

            if (successRegister)
            {
                await _eventBus.SendCommand(new CreatePaymentCommand(order.Id, order.CustomerId, order.Total));
            }

            return successRegister;
        }
    }
}
