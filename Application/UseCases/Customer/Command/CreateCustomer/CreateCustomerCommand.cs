using System;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : RequestData<CustomerEn> , IRequest<CreateCustomerCommandDto>
    {
        
    }
}