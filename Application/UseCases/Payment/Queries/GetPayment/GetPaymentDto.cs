using FluentVal_Task.Application.UseCases.Payment.Models;
using FluentVal_Task.Application.Models.Query;

namespace FluentVal_Task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentDto : BaseDto
    {
        public PaymentData Data { get; set; }
    }
}