using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(i => i.DataD.Attributes.Name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(i => i.DataD.Attributes.Name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(i => i.DataD.Attributes.Price).NotEmpty().WithMessage("price can't be empty");
            RuleFor(i => i.DataD.Attributes.Price).GreaterThan(1000).WithMessage("price must be greater than 1000");
        }
    }
}