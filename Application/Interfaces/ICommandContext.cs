using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.Interfaces
{
    public interface ICommandContext
    {
        DbSet<CustomerEn>  Customers { get; set; }
        DbSet<MerchantEn> Merchants { get; set; }
        DbSet<PaymentEn> Payments { get; set; }
        DbSet<ProductEn> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}