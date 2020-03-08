using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Customer.Models;
using FluentVal_Task.Application.Interfaces;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
         private readonly ICommandContext _context;

         public GetCustomersQueryHandler(ICommandContext context)
         {
             _context = context;
         }

         public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellation)
         {
            var data = await _context.Customers.ToListAsync();

            return new GetCustomersDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}