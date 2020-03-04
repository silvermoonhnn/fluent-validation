using System;
using FluentValidation;
using FluentVal_Task.Entities;

namespace FluentVal_Task.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.NameOnCard).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(x => x.NameOnCard).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.ExpMonth).NotEmpty().WithMessage("exp_month can't be empty");
            RuleFor(x => Convert.ToInt32(x.ExpMonth)).InclusiveBetween(1,12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.ExpYear).NotEmpty().WithMessage("exp_year can't be empty");
            RuleFor(x => x.CreditCardNum).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }   
    }
}