using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Models;
using System;

namespace FluentVal_Task
{
    public class FluentContext : DbContext
    {
        public FluentContext(DbContextOptions<FluentContext> op) : base (op) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model
                .Entity<Payment>()
                .HasOne(i => i.customer)
                .WithMany()
                .HasForeignKey(i => i.Customer_Id);
            model 
                .Entity<Product>()
                .HasOne(i => i.merchant)
                .WithMany()
                .HasForeignKey(i => i.Merchant_Id);
        }
    }
}