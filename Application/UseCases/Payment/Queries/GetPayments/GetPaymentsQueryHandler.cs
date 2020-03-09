using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentVal_Task.Infrastructure.Presistance;

namespace FluentVal_Task.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, GetPaymentsDto>
    {
         private readonly FluentContext _context;

         public GetPaymentsQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetPaymentsDto> Handle(GetPaymentsQuery request, CancellationToken cancellation)
         {
            var data = await _context.Payments.ToListAsync();

            return new GetPaymentsDto 
            {
                Success = true,
                Message = "Customer successfully retrieved",
                Data = data
            };
         }
    }
   


}