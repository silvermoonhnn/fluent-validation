using MediatR;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerDto>
    {
        public int Id { get; set; }
    }
}