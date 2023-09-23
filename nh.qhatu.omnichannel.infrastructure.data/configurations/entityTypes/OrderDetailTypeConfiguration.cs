using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.omnichannel.domain.core.entities;
using System.Reflection.Emit;

namespace nh.qhatu.omnichannel.infrastructure.data.configurations.entityTypes
{
    public class OrderDetailTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("order_detail");

            builder.Property(e => e.OrderId).HasColumnName("order_id");

            builder.Property(e => e.ProductId).HasColumnName("product_id");

            builder.Property(e => e.Quantity).HasColumnName("quantity");

            builder.HasKey(k => new { k.OrderId, k.ProductId });

            builder.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_detail_order");
        }
    }
}