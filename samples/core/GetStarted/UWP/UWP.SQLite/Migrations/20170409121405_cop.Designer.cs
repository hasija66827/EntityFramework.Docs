using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFGetStarted.UWP;

namespace EFGetStarted.UWP.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20170409121405_cop")]
    partial class cop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("EFGetStarted.UWP.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EFGetStarted.UWP.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsVerifiedUser");

                    b.Property<string>("MobileNo");

                    b.Property<string>("Name");

                    b.HasKey("CustomerId");

                    b.HasIndex("MobileNo")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EFGetStarted.UWP.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("BillAmount");

                    b.Property<Guid?>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime>("OrderDate");

                    b.Property<float>("PaidAmount");

                    b.Property<float>("WalletSnapShot");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EFGetStarted.UWP.OrderProduct", b =>
                {
                    b.Property<Guid>("OrderProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("DiscountPerSnapShot");

                    b.Property<float>("DisplayCostSnapShot");

                    b.Property<Guid?>("OrderId")
                        .IsRequired();

                    b.Property<Guid?>("ProductId")
                        .IsRequired();

                    b.Property<int>("QuantityPurchased");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("EFGetStarted.UWP.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EFGetStarted.UWP.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarCode");

                    b.Property<float>("DiscountPer");

                    b.Property<float>("DisplayPrice");

                    b.Property<bool>("IsInventoryItem");

                    b.Property<int>("RefillTime");

                    b.Property<int>("Threshold");

                    b.Property<string>("UserDefinedCode");

                    b.HasKey("ProductId");

                    b.HasIndex("BarCode")
                        .IsUnique();

                    b.HasIndex("UserDefinedCode")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFGetStarted.UWP.Order", b =>
                {
                    b.HasOne("EFGetStarted.UWP.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGetStarted.UWP.OrderProduct", b =>
                {
                    b.HasOne("EFGetStarted.UWP.Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGetStarted.UWP.Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGetStarted.UWP.Post", b =>
                {
                    b.HasOne("EFGetStarted.UWP.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
