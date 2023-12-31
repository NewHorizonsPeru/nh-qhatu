﻿using Microsoft.EntityFrameworkCore;
using nh.qhatu.omnichannel.domain.entities;
using nh.qhatu.omnichannel.domain.interfaces;
using nh.qhatu.omnichannel.infrastructure.context;

namespace nh.qhatu.omnichannel.infrastructure.repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OmnichannelContext context) : base(context) { }

        public IEnumerable<Order> GetAllWithDetail()
        {
            return _context.Order.Include(i => i.OrderDetails);
        }
    }
}
