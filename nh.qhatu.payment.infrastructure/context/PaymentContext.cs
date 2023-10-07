using Microsoft.EntityFrameworkCore;
using nh.qhatu.payment.domain.entities;
using nh.qhatu.payment.infrastructure.configurations.entityTypes;

namespace nh.qhatu.payment.infrastructure.context
{
    public partial class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
