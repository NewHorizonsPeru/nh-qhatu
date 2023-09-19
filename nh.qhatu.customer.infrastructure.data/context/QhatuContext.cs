using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using nh.qhatu.customer.domain.core.entities;
using nh.qhatu.customer.infrastructure.data.configurations.entityTypes;

namespace nh.qhatu.customer.infrastructure.data.context
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

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressEntityTypeConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
