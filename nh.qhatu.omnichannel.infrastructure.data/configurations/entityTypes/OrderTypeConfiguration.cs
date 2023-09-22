using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.omnichannel.domain.core.entities;

namespace nh.qhatu.omnichannel.infrastructure.data.configurations.entityTypes
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.CustomerId).HasColumnName("customer_id");

            builder.Property(e => e.PaymentId).HasColumnName("payment_id");

            builder.Property(e => e.State).HasColumnName("state");

            builder.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.Payment)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_payment");
            
        }
    }
}
