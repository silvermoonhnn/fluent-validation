using System.Threading;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
         private readonly FluentContext _context;

         public GetProductQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellation)
         {
             var result = await _context.Products.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetProductDto
             {
                 Success = true,
                 Message = "Product successfully retrieved",
                 Data = result
             };
         }
    }
   


}