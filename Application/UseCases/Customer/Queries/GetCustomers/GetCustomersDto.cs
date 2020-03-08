using System.Collections.Generic;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersDto : BaseDto
    {
        public IList<CustomerEn> Data { get; set; }
    }
}