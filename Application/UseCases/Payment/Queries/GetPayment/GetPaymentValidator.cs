using FluentValidation;
using FluentVal_Task.Application.UseCases.Payment.Models;

namespace FluentVal_Task.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentValidator : AbstractValidator<GetPaymentQuery>
    {
        public GetPaymentValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}