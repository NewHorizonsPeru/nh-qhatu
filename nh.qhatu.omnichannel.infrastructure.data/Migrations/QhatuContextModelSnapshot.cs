﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nh.qhatu.omnichannel.infrastructure.data.context;

#nullable disable

namespace nh.qhatu.omnichannel.infrastructure.data.Migrations
{
    [DbContext(typeof(QhatuContext))]
    partial class QhatuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("nh.qhatu.omnichannel.domain.core.entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("customer_id");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("payment_id");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("nh.qhatu.omnichannel.domain.core.entities.OrderDetail", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("order_id");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total");

                    b.HasKey("OrderId", "ProductId");

                    b.ToTable("order_detail", (string)null);
                });

            modelBuilder.Entity("nh.qhatu.omnichannel.domain.core.entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("customer_id");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.ToTable("payment", (string)null);
                });

            modelBuilder.Entity("nh.qhatu.omnichannel.domain.core.entities.Order", b =>
                {
                    b.HasOne("nh.qhatu.omnichannel.domain.core.entities.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .IsRequired()
                        .HasConstraintName("FK_order_payment");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("nh.qhatu.omnichannel.domain.core.entities.OrderDetail", b =>
                {
                    b.HasOne("nh.qhatu.omnichannel.domain.core.entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_order_detail_order");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("nh.qhatu.omnichannel.domain.core.entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("nh.qhatu.omnichannel.domain.core.entities.Payment", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
