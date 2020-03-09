using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentVal_Task.Application.Interfaces;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDto>
    {
         private readonly ICommandContext _context;

         public GetMerchantsQueryHandler(ICommandContext context)
         {
             _context = context;
         }

         public async Task<GetMerchantsDto> Handle(GetMerchantsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Merchants.ToListAsync();

            return new GetMerchantsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}