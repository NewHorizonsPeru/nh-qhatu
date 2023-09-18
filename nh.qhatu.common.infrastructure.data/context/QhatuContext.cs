using Microsoft.EntityFrameworkCore;
using nh.qhatu.common.domain.core.entities;
using nh.qhatu.common.infrastructure.data.configurations.entityTypes;

namespace nh.qhatu.common.infrastructure.data.context
{
    public partial class QhatuContext : DbContext
    {
        public QhatuContext()
        {
        }

        public QhatuContext(DbContextOptions<QhatuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CreditCardType> CreditCardTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardTypeEntityTypeConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
