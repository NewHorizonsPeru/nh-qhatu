﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.omnichannel.domain.core.entities;

namespace nh.qhatu.omnichannel.infrastructure.data.configurations.entityTypes
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");

            builder.Property(e => e.CustomerId).HasColumnName("customer_id");

            builder.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");
        }
    }
}
