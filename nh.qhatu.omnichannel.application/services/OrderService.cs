using AutoMapper;
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
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public ICollection<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllWithDetail();
            var ordersDto = _mapper.Map<ICollection<OrderDto>>(orders);
            return ordersDto;
        }

        public async void CreateOrder(CreateOrderDto orderDto) 
        {
            var order = _mapper.Map<Order>(orderDto);
            var orderDetail = order.OrderDetails;
            var productExistence = true;

            foreach (var itemOrderDetail in orderDetail)
            {
                var productId = itemOrderDetail.ProductId;
                var product = await _productRepository.ValidateProductExistence(productId);
                if (product == null)
                {
                    productExistence = false;
                    break;
                }
            }

            if (productExistence)
            {
                _orderRepository.Add(order);
                _orderRepository.Save();

            }

        }
    }
}
