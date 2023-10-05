using Microsoft.EntityFrameworkCore;
using nh.qhatu.common.domain.entities;
using nh.qhatu.common.infrastructure.configurations.entityTypes;

namespace nh.qhatu.common.infrastructure.context
{
    public partial class CommonContext : DbContext
    {
        public CommonContext()
        {
        }

        public CommonContext(DbContextOptions<CommonContext> options)
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
