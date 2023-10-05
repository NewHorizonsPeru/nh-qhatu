using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.homedelivery.domain.entities;

namespace nh.qhatu.homedelivery.infrastructure.configurations.entityTypes
{
    public class HomeDeliveryTypeConfiguration : IEntityTypeConfiguration<HomeDelivery>
    {
        public void Configure(EntityTypeBuilder<HomeDelivery> builder)
        {
            builder.ToTable("home_delivery");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.AddressId)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("address_id");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");

            builder.Property(e => e.CustomerId).HasColumnName("customer_id");

            builder.Property(e => e.OrderId).HasColumnName("order_id");

            builder.Property(e => e.State).HasColumnName("state");
        }
    }
}
