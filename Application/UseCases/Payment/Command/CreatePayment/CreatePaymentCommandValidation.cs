using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(i => i.DataD.Attributes.NameOnCard).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(i => i.DataD.Attributes.NameOnCard).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(i => i.DataD.Attributes.ExpMonth).NotEmpty().WithMessage("exp_month can't be empty");
            RuleFor(i => Convert.ToInt32(i.DataD.Attributes.ExpMonth)).InclusiveBetween(1,12).WithMessage("exp_month is bettween 1-12");
            RuleFor(i => i.DataD.Attributes.ExpYear).NotEmpty().WithMessage("exp_year can't be empty");
            RuleFor(i => i.DataD.Attributes.CreditCardNum).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }   
    }
}