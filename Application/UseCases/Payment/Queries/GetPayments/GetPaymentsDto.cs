using System.Collections.Generic;
using FluentVal_Task.Application.UseCases.Payment.Models;
using FluentVal_Task.Application.Models.Query;

namespace FluentVal_Task.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsDto : BaseDto
    {
        public IList<PaymentData> Data { get; set; }
    }
}