﻿using nh.qhatu.omnichannel.application.dto;
using nh.qhatu.omnichannel.application.dto.Creates;

namespace nh.qhatu.omnichannel.application.interfaces
{
    public interface IOrderService
    {
        ICollection<OrderDto> GetAllOrders();
        void CreateOrder(CreateOrderDto orderDto);
    }
}
