using System;
using FluentValidation;
using FluentVal_Task.Entities;

namespace FluentVal_Task.Validators
{
    public class MerchantValidator : AbstractValidator<Merchant>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(x => x.Address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => Convert.ToInt32(x.Rating)).InclusiveBetween(1,5).WithMessage("rating is bettween 1-5");
        }   
    }
}