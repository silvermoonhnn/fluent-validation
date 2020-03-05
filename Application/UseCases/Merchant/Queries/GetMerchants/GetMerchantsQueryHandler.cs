using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Merchant.Models;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDto>
    {
         private readonly FluentContext _context;

         public GetMerchantsQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetMerchantsDto> Handle(GetMerchantsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Merchants.ToListAsync();

            var result = data.Select(i => new MerchantData
            {
                Name = i.Name,
                Address = i.Address
            });

            return new GetMerchantsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = result.ToList()
            };
         }
    }
   


}