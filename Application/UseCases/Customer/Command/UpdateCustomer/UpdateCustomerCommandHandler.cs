using System;
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Application.Interfaces;
using MediatR;


namespace FluentVal_Task.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandDto>
    {
        private readonly ICommandContext _context;
        
        public UpdateCustomerCommandHandler(ICommandContext context)
        {
            _context = context;
        }

        public async Task<UpdateCustomerCommandDto> Handle(UpdateCustomerCommand request, CancellationToken cancellation)
        {
            var customer = _context.Customers.Find(request.DataD.Attributes.Id);
            
            customer.Fullname = request.DataD.Attributes.Fullname;
            customer.Username = request.DataD.Attributes.Username;
            customer.Birthdate = request.DataD.Attributes.Birthdate;
            customer.Gender = request.DataD.Attributes.Gender;
            customer.Email = request.DataD.Attributes.Email;

            await _context.SaveChangesAsync(cancellation);

            return new UpdateCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully updated"
            };
        }
    }
}