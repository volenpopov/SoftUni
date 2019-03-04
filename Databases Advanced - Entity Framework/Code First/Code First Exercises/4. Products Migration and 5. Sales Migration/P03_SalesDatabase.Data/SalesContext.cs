
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-4O9GE86;Database=Sales;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasDefaultValue("No description");

            modelBuilder.Entity<Sale>()
                .Property(p => p.Date)
                .HasDefaultValueSql("GetUtcDate()");

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasMany(x => x.Sales)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.CustomerId);
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.HasMany(x => x.Sales)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<Store>(e =>
            {
                e.HasMany(x => x.Sales)
                    .WithOne(x => x.Store)
                    .HasForeignKey(x => x.StoreId);
            });
        }
    }
}
