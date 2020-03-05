using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Customer.Models;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
         private readonly FluentContext _context;

         public GetCustomersQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellation)
         {
            var data = await _context.Customers.ToListAsync();

            var result = data.Select(i => new CustomerData
            {
                Username = i.Username,
                Email = i.Email
            });

            return new GetCustomersDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = result.ToList()
            };
         }
    }
   


}