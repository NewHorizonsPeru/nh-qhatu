using AutoMapper;
using MassTransit;
using nh.qhatu.infrasctructure.crosscutting;
using nh.qhatu.omnichannel.application.dto;
using nh.qhatu.omnichannel.application.dto.creates;
using nh.qhatu.omnichannel.application.interfaces;
using nh.qhatu.omnichannel.domain.entities;
using nh.qhatu.omnichannel.domain.interfaces;

namespace nh.qhatu.omnichannel.application.services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndPoint;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IPublishEndpoint publishEndPoint, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _publishEndPoint = publishEndPoint;
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
                await _publishEndPoint.Publish(new CreatePaymentEvent(order.Id, order.CustomerId, order.Total));
            }

            return successRegister;
        }
    }
}
