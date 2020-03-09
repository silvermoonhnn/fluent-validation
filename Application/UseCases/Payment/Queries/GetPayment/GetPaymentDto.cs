using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentDto : BaseDto
    {
        public PaymentEn Data { get; set; }
    }
}