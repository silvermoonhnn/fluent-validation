using System;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandDto>
    {
        public CreateCustomerData Data { get; set; }
    }

    public class CreateCustomerData
    {
        public string Username { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
    }
}