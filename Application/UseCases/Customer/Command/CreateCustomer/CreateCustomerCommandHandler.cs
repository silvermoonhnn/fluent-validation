using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;

namespace FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandDto>
    {
        private readonly FluentContext _context;

        public CreateCustomerCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerCommandDto> Handle(CreateCustomerCommand request, CancellationToken cancellation)
        {
            var customer = new Domain.Entities.Customer
            {
                Username = request.Data.Username,
                Email = request.Data.Email,
                Gender = request.Data.Gender,
                Birthdate = request.Data.Birthdate
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellation);

            return new CreateCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully created"
            };

        }
    }
}