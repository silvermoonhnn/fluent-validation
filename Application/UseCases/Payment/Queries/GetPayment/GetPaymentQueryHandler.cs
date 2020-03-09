using System.Threading;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FluentVal_Task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, GetPaymentDto>
    {
         private readonly FluentContext _context;

         public GetPaymentQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetPaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellation)
         {
             var result = await _context.Payments.FirstOrDefaultAsync( i => i.Id == request.Id);

             return new GetPaymentDto
             {
                 Success = true,
                 Message = "Payment successfully retrieved",
                 Data = result
             };
         }
    }
   


}