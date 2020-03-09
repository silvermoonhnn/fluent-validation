using System.Collections.Generic;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsDto : BaseDto
    {
        public IList<PaymentEn> Data { get; set; }
    }
}