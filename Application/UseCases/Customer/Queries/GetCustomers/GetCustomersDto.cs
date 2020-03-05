using System.Collections.Generic;
using FluentVal_Task.Application.UseCases.Customer.Models;
using FluentVal_Task.Application.Models.Query;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersDto : BaseDto
    {
        public IList<CustomerData> Data { get; set; }
    }
}