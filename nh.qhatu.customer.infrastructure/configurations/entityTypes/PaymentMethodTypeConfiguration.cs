using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.customer.domain.entities;

namespace nh.qhatu.customer.infrastructure.configurations.entityTypes
{
    public class PaymentMethodTypeConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("payment_method");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(c => c.Id);

            builder.Property(e => e.Active).HasColumnName("active");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.CreditCardNumber)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("credit_card_number");

            builder.Property(e => e.CreditCardTypeId).HasColumnName("credit_card_type_id");

            builder.Property(e => e.CustomerId).HasColumnName("customer_id");

            builder.Property(e => e.ExpirationDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("expiration_date");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_payment_method_customer");
        }
    }
}
