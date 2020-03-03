using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Models;

namespace FluentVal_Task
{
    public class FluentContext : DbContext
    {
        public FluentContext(DbContextOptions<FluentContext> op) : base (op) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}