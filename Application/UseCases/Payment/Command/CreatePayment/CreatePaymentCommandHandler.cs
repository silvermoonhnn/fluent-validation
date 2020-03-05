using System.ComponentModel.DataAnnotations;
using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;

namespace FluentVal_Task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandDto>
    {
        private readonly FluentContext _context;

        public CreatePaymentCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<CreatePaymentCommandDto> Handle(CreatePaymentCommand request, CancellationToken cancellation)
        {
            var payment = new Domain.Entities.Payment
            {
                Customer_Id = request.Data.Customer_Id,
                NameOnCard = request.Data.NameOnCard,
                ExpMonth = request.Data.ExpMonth,
                ExpYear = request.Data.ExpYear,
                CreditCardNum = request.Data.CreditCardNum
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(cancellation);

            return new CreatePaymentCommandDto
            {
                Success = true,
                Message = "Merchant successfully created"
            };

        }
    }
}