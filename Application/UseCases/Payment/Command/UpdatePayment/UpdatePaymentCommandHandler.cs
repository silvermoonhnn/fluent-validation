using System;
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;


namespace FluentVal_Task.Application.UseCases.Payment.Command.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, UpdatePaymentCommandDto>
    {
        private readonly FluentContext _context;
        
        public UpdatePaymentCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<UpdatePaymentCommandDto> Handle(UpdatePaymentCommand request, CancellationToken cancellation)
        {
            var payment = _context.Payments.Find(request.DataD.Attributes.Id);
            
            payment.Customer_Id = request.DataD.Attributes.Customer_Id;
            payment.NameOnCard = request.DataD.Attributes.NameOnCard;
            payment.ExpMonth = request.DataD.Attributes.ExpMonth;
            payment.ExpYear = request.DataD.Attributes.ExpYear;
            payment.CreditCardNum = request.DataD.Attributes.CreditCardNum;

            await _context.SaveChangesAsync(cancellation);

            return new UpdatePaymentCommandDto
            {
                Success = true,
                Message = "Payment successfully updated"
            };
        }
    }
}