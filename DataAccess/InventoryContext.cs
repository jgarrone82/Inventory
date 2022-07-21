using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class InventoryContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<WarehouseEntity> Warehouses { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
        public DbSet<TransactionEntity> InOuts { get; set; }

        #region fluentAPI

        //public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CategoryEntity>(category => {                
        //        category.ToTable("Categories");
        //        category.HasKey(p => p.CategoryId);
        //        category.Property(p => p.CategoryName).IsRequired().HasMaxLength(100);
        //    });

        //    modelBuilder.Entity<ProductEntity>(product => {
        //        product.ToTable("Products");
        //        product.HasKey(p => p.ProductId);
        //        product.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
        //        product.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
        //        product.Property(p => p.ProductDescription).IsRequired(false).HasMaxLength(600);
        //        product.Property(p => p.TotalQuantity).IsRequired().HasMaxLength(10);
        //    });

        //    modelBuilder.Entity<WarehouseEntity>(warehouse => {
        //        warehouse.ToTable("Warehouses");
        //        warehouse.HasKey(p => p.WarehouseId);
        //        warehouse.Property(p => p.WarehouseName).IsRequired().HasMaxLength(100);
        //        warehouse.Property(p => p.WarehouseAddress).IsRequired().HasMaxLength(300);
        //    });

        //    modelBuilder.Entity<StorageEntity>(storage => {
        //        storage.ToTable("Storages");
        //        storage.HasKey(p => p.StorageId);
        //        storage.HasOne(p => p.Product).WithMany(p => p.Storages).HasForeignKey(p => p.ProductId);
        //        storage.HasOne(p => p.Warehouse).WithMany(p => p.Storages).HasForeignKey(p => p.WarehouseId);
        //        storage.Property(p => p.LastUpdate).IsRequired();
        //        storage.Property(p => p.PartialQuantity).IsRequired();
        //    });

        //    modelBuilder.Entity<TransactionEntity>(inOut => {
        //        inOut.ToTable("InputsOuputs");
        //        inOut.HasKey(p => p.InOutId);
        //        inOut.HasOne(p => p.Storage).WithMany(p => p.InputOutputs).HasForeignKey(p => p.StorageId);
        //        inOut.Property(p => p.InOutDate).IsRequired();
        //        inOut.Property(p => p.Quantity).IsRequired();
        //        inOut.Property(p => p.IsInput).IsRequired();
        //    });
        //}
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseSqlServer("Server=CELL-200016; Database=InventoryDb;User Id=sa; Password=jOrgE1982;Connection Timeout=30;");
                //Data Source=CELL-200016;Initial Catalog=taskDb
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { CategoryId = "ASH", CategoryName = "Aseo Hogar" },
                new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal" },
                new CategoryEntity { CategoryId = "HGR", CategoryName = "Hogar" },
                new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumería" },
                new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud" },
                new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
                );

            modelBuilder.Entity<WarehouseEntity>().HasData(
                new WarehouseEntity { WarehouseId = Guid.NewGuid(), WarehouseName = "Bodega Central", WarehouseAddress = "Calle 8 con 23" },
                new WarehouseEntity { WarehouseId = Guid.NewGuid(), WarehouseName = "Bodega Norte", WarehouseAddress = "Calle norte con occidente" }
                );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { ProductId = "ASJ-98745", ProductName = "Crema para manos marca Tersa", ProductDescription = "", CategoryId = "PRF" },
                new ProductEntity { ProductId = "RPT-5465879", ProductName = "Pastillas para la garganta LESUS", ProductDescription = "", CategoryId = "SLD" }
                );
        }
    }
}
