using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.customer.domain.entities;

namespace nh.qhatu.customer.infrastructure.configurations.entityTypes
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.Property(e => e.IdCardNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("id_card_number");

            builder.Property(e => e.LastNames)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("last_names");

            builder.Property(e => e.Names)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("names");

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        }
    }
}
