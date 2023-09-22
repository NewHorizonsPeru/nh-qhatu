using Microsoft.EntityFrameworkCore;
using nh.qhatu.homedelivery.domain.core.entities;
using nh.qhatu.homedelivery.infrastructure.data.configurations.entityTypes;

namespace nh.qhatu.homedelivery.infrastructure.data.context
{
    public partial class QhatuContext : DbContext
    {
        public QhatuContext(DbContextOptions<QhatuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HomeDelivery> HomeDelivery { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HomeDeliveryTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
