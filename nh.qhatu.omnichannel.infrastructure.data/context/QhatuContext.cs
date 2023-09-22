using Microsoft.EntityFrameworkCore;
using nh.qhatu.omnichannel.domain.core.entities;

namespace nh.qhatu.omnichannel.infrastructure.data.context
{
    public partial class QhatuContext : DbContext
    {
        public QhatuContext(DbContextOptions<QhatuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetail { get; set; } = null!;
        public virtual DbSet<Payment> Payment { get; set; } = null!;
    }
}
