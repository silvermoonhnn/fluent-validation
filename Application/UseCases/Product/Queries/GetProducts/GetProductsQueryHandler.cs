using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentVal_Task.Infrastructure.Presistance;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsDto>
    {
         private readonly FluentContext _context;

         public GetProductsQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetProductsDto> Handle(GetProductsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Products.ToListAsync();

            return new GetProductsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}