﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.CategoryEntity", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "MPH",
                            CategoryName = "Mobile Phones"
                        },
                        new
                        {
                            CategoryId = "ELT",
                            CategoryName = "Electronics"
                        },
                        new
                        {
                            CategoryId = "FUR",
                            CategoryName = "Furniture"
                        },
                        new
                        {
                            CategoryId = "VDG",
                            CategoryName = "Videogames"
                        },
                        new
                        {
                            CategoryId = "OFC",
                            CategoryName = "Office"
                        },
                        new
                        {
                            CategoryId = "PCR",
                            CategoryName = "Personal Care"
                        });
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(600)")
                        .HasMaxLength(600);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = "MPH-98745",
                            CategoryId = "MPH",
                            ProductDescription = "",
                            ProductName = "Samsung Galaxy S22 +",
                            TotalQuantity = 0
                        },
                        new
                        {
                            ProductId = "VDG-54658",
                            CategoryId = "VDG",
                            ProductDescription = "",
                            ProductName = "Nintendo Switch Neon 64 Gb",
                            TotalQuantity = 0
                        });
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartialQuantity")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("WarehouseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WarehouseId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StorageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId1");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Entities.TransactionEntity", b =>
                {
                    b.Property<string>("InOutId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("InOutDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInput")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InOutId");

                    b.HasIndex("StorageId");

                    b.ToTable("InOuts");
                });

            modelBuilder.Entity("Entities.WarehouseEntity", b =>
                {
                    b.Property<Guid>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasMaxLength(50);

                    b.Property<string>("WarehouseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            WarehouseId = new Guid("e87cb30e-c38b-4213-b2d1-20842fe6357e"),
                            WarehouseAddress = "4709 Plume Rd NW",
                            WarehouseName = "Central Warehouse"
                        },
                        new
                        {
                            WarehouseId = new Guid("3474c4b3-08d6-4b96-b544-7ad44f4a5c3e"),
                            WarehouseAddress = "425 San Felipe St NW",
                            WarehouseName = "North Warehouse"
                        });
                });

            modelBuilder.Entity("Entities.ProductEntity", b =>
                {
                    b.HasOne("Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Entities.StorageEntity", b =>
                {
                    b.HasOne("Entities.ProductEntity", "Product")
                        .WithMany("Storages")
                        .HasForeignKey("ProductId");

                    b.HasOne("Entities.WarehouseEntity", "Warehouse")
                        .WithMany("Storages")
                        .HasForeignKey("WarehouseId1");
                });

            modelBuilder.Entity("Entities.TransactionEntity", b =>
                {
                    b.HasOne("Entities.StorageEntity", "Storage")
                        .WithMany("InputOutputs")
                        .HasForeignKey("StorageId");
                });
#pragma warning restore 612, 618
        }
    }
}
