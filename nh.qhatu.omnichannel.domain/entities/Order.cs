﻿namespace nh.qhatu.omnichannel.domain.entities
{
    public partial class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string CustomerId { get; set; } = null!;
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
