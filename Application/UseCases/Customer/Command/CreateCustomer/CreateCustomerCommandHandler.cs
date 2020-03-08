using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Domain.Entities;
using FluentVal_Task.Application.Interfaces;

namespace FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandDto>
    {
        private readonly ICommandContext _context;

        public CreateCustomerCommandHandler(ICommandContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerCommandDto> Handle(CreateCustomerCommand request, CancellationToken cancellation)
        {
            var customers = new Domain.Entities.CustomerEn
            {
                Fullname = request.DataD.Attributes.Fullname,
                Username = request.DataD.Attributes.Username,
                Birthdate = request.DataD.Attributes.Birthdate,
                Gender = request.DataD.Attributes.Gender,
                Email = request.DataD.Attributes.Email
            };

            if (request.DataD.Attributes.Gender == "male")
            {
                customers.Sex = Gender.Male;
            }
            else if (request.DataD.Attributes.Gender == "female")
            {
                customers.Sex = Gender.Female;
            }

             _context.Customers.Add(customers);
            await _context.SaveChangesAsync(cancellation);

            return new CreateCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully created"
            };

        }
    }
}