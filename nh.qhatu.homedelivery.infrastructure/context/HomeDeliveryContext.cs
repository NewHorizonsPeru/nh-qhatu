using Microsoft.EntityFrameworkCore;
using nh.qhatu.homedelivery.domain.entities;
using nh.qhatu.homedelivery.infrastructure.configurations.entityTypes;

namespace nh.qhatu.homedelivery.infrastructure.context
{
    public partial class HomeDeliveryContext : DbContext
    {
        public HomeDeliveryContext(DbContextOptions<HomeDeliveryContext> options)
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
