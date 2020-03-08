using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Application.Interfaces;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDto>
    {
         private readonly ICommandContext _context;

         public GetMerchantQueryHandler(ICommandContext context)
         {
             _context = context;
         }

         public async Task<GetMerchantDto> Handle(GetMerchantQuery request, CancellationToken cancellation)
         {
             var result = await _context.Merchants.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetMerchantDto
             {
                 Success = true,
                 Message = "Merchant successfully retrieved",
                 Data = result
             };
         }
    }
   


}