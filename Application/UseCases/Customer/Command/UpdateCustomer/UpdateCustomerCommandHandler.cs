using System;
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;


namespace FluentVal_Task.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandDto>
    {
        private readonly FluentContext _context;
        
        public UpdateCustomerCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<UpdateCustomerCommandDto> Handle(UpdateCustomerCommand request, CancellationToken cancellation)
        {
            var customer = _context.Customers.Find(request.Data.Id);

            customer.Fullname = request.Data.Fullname;


            await _context.SaveChangesAsync(cancellation);

            return new UpdateCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully updated"
            };
        }
    }
}