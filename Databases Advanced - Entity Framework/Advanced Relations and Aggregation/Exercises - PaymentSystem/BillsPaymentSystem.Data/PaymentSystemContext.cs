using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BillsPaymentSystem.Data
{
    public class PaymentSystemContext : DbContext
    {
        public PaymentSystemContext()
        { }

        public PaymentSystemContext(DbContextOptions options) 
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<PaymentMethod> PaymentMethod { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=DESKTOP-MFJ6K8M\SQLEXPRESS;Database=PaymentSystem;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
