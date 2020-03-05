using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Product.Models;

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

            var result = data.Select(i => new ProductData
            {
                Merchant_Id = i.Merchant_Id,
                Name = i.Name,
                Price = i.Price
            });

            return new GetProductsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = result.ToList()
            };
         }
    }
   


}