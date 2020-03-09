using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Infrastructure.Presistance;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
         private readonly FluentContext _context;

         public GetCustomerQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellation)
         {
             var result = await _context.Customers.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetCustomerDto
             {
                 Success = true,
                 Message = "Customer successfully retrieved",
                 Data = result
             };
         }
    }
}