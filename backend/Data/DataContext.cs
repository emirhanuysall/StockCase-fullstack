using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(d => d.Stock)
                .WithMany()
                .HasForeignKey(d => d.StockId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany()
                .HasForeignKey(i => i.CustomerId);
        }
    }
}

