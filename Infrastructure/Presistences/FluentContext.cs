using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Domain.Entities;
using System;

namespace FluentVal_Task.Infrastructure.Presistance
{
    public class FluentContext : DbContext
    {
        public FluentContext(DbContextOptions<FluentContext> op) : base (op) {}

        public DbSet<CustomerEn> Customers { get; set; }
        public DbSet<MerchantEn> Merchants { get; set; }
        public DbSet<PaymentEn> Payments { get; set; }
        public DbSet<ProductEn> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model
                .Entity<PaymentEn>()
                .HasOne(i => i.customer)
                .WithMany()
                .HasForeignKey(i => i.Customer_Id);
            model 
                .Entity<ProductEn>()
                .HasOne(i => i.merchant)
                .WithMany()
                .HasForeignKey(i => i.Merchant_Id);
        }
    }
}