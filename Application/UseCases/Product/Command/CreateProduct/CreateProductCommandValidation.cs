using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(i => i.Data.Name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(i => i.Data.Name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(i => i.Data.Price).NotEmpty().WithMessage("price can't be empty");
            RuleFor(i => i.Data.Price).GreaterThan(1000).WithMessage("price must be greater than 1000");
        }
    }
}