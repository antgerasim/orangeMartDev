using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orangeMartDev.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //services
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(Entity))))
            {
                modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property("CreatedAt")
                        .HasDefaultValueSql("getutcdate()");
                        x.Property("CreatedBy")
                        .HasDefaultValue(Guid.Empty);//system
                        x.Property("IsDeleted")
                        .HasDefaultValue(false);
                    });
            }
            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Receipt>()
                .Property(p => p.PaymentAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Receipt>()
                .Property(p => p.Tax)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Receipt>()
                .Property(p => p.Total)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Category>()
                .Property(p => p.TaxRate)
                .HasColumnType("decimal(18,2)");

            //https://mattferderer.com/entity-framework-no-type-was-specified-for-the-decimal-column
        }
    }
}
