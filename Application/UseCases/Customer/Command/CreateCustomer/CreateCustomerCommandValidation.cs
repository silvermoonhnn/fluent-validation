using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(i => i.Data.Username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(i => i.Data.Username).MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(i => i.Data.Email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(i => i.Data.Email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(i => i.Data.Gender).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(i => i.Data.Gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(i => i.Data.Birthdate).NotEmpty().WithMessage("birhdate can't be empty");
            RuleFor(i => DateTime.Now.Year - i.Data.Birthdate.Year).GreaterThan(18).WithMessage("age must be greater than 18");
        }
    }
}