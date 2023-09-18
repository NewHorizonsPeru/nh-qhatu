using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.common.domain.core.entities;

namespace nh.qhatu.common.infrastructure.data.configurations.entityTypes
{
    internal class CreditCardTypeEntityTypeConfiguration : IEntityTypeConfiguration<CreditCardType>
    {
        public void Configure(EntityTypeBuilder<CreditCardType> builder)
        {
            builder.ToTable("credit_card_type");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at")
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(e => e.Description)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("description");
        }
    }
}
