using System;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandDto>
    {
        public CustomerEn Data { get; set; }
    }
}