using Microsoft.EntityFrameworkCore;
using nh.qhatu.omnichannel.domain.entities;
using nh.qhatu.omnichannel.infrastructure.configurations.entityTypes;

namespace nh.qhatu.omnichannel.infrastructure.context
{
    public partial class OmnichannelContext : DbContext
    {
        public OmnichannelContext(DbContextOptions<OmnichannelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetail { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderDetailTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
