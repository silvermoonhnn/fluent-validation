using System.Threading;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDto>
    {
         private readonly FluentContext _context;

         public GetMerchantQueryHandler(FluentContext context)
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
                 Data = new Models.MerchantData
                 {
                    Name = result.Name,
                    Address = result.Address
                 }
             };
         }
    }
   


}