
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Customer.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : RequestData<CustomerEn>,IRequest<UpdateCustomerCommandDto>
    {
        
    }
}