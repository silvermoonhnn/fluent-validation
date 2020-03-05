using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(i => i.Data.NameOnCard).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(i => i.Data.NameOnCard).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(i => i.Data.ExpMonth).NotEmpty().WithMessage("exp_month can't be empty");
            RuleFor(i => Convert.ToInt32(i.Data.ExpMonth)).InclusiveBetween(1,12).WithMessage("exp_month is bettween 1-12");
            RuleFor(i => i.Data.ExpYear).NotEmpty().WithMessage("exp_year can't be empty");
            RuleFor(i => i.Data.CreditCardNum).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }   
    }
}