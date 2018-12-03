﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using orangeMartDev.Data;

namespace orangeMartDev.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("orangeMartDev.Data.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<Guid>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.Property<decimal>("TaxRate");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("orangeMartDev.Data.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentAmount");

                    b.Property<DateTime>("LastModified");

                    b.Property<Guid>("LastModifiedBy");

                    b.Property<Guid?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("orangeMartDev.Data.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<string>("DiscountModifier");

                    b.Property<DateTime>("LastModified");

                    b.Property<Guid>("LastModifiedBy");

                    b.Property<int>("ListingStatus");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("orangeMartDev.Data.Receipt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CashierId");

                    b.Property<DateTime>("LastModified");

                    b.Property<Guid>("LastModifiedBy");

                    b.Property<Guid?>("ManagerId");

                    b.Property<string>("OrderName");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PaymentType");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("orangeMartDev.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<DateTime>("LastModified");

                    b.Property<Guid>("LastModifiedBy");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("orangeMartDev.Data.Inventory", b =>
                {
                    b.HasOne("orangeMartDev.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("orangeMartDev.Data.Product", b =>
                {
                    b.HasOne("orangeMartDev.Data.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("orangeMartDev.Data.Receipt", b =>
                {
                    b.HasOne("orangeMartDev.Data.User", "Cashier")
                        .WithMany()
                        .HasForeignKey("CashierId");

                    b.HasOne("orangeMartDev.Data.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("orangeMartDev.Data.User", b =>
                {
                    b.OwnsOne("orangeMartDev.Data.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("First");

                            b1.Property<string>("Last");

                            b1.Property<string>("Middle");

                            b1.ToTable("Users");

                            b1.HasOne("orangeMartDev.Data.User")
                                .WithOne("Name")
                                .HasForeignKey("orangeMartDev.Data.Name", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}