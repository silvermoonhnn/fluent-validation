using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandValidator : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantCommandValidator()
        {
            RuleFor(i => i.Data.Name).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(i => i.Data.Address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(i => Convert.ToInt32(i.Data.Rating)).InclusiveBetween(1,5).WithMessage("rating is bettween 1-5");
        }
    }
}