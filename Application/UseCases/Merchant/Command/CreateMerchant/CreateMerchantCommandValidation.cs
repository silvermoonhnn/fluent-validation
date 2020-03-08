using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandValidator : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantCommandValidator()
        {
            RuleFor(i => i.DataD.Attributes.Name).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(i => i.DataD.Attributes.Address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(i => Convert.ToInt32(i.DataD.Attributes.Rating)).InclusiveBetween(1,5).WithMessage("rating is bettween 1-5");
        }
    }
}