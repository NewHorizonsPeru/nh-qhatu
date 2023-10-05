using Microsoft.EntityFrameworkCore;
using nh.qhatu.omnichannel.domain.entities;
using nh.qhatu.omnichannel.infrastructure.sqlServer.configurations.entityTypes;

namespace nh.qhatu.omnichannel.infrastructure.sqlServer.context
{
    public partial class OmnichannelContext : DbContext
    {
        public OmnichannelContext(DbContextOptions<OmnichannelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetail { get; set; } = null!;
        public virtual DbSet<Payment> Payment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderDetailTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
