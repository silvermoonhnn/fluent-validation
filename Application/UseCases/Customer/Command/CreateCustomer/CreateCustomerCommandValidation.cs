using System;
using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(i => i.DataD.Attributes.Username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(i => i.DataD.Attributes.Username).MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(i => i.DataD.Attributes.Email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(i => i.DataD.Attributes.Email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(i => i.DataD.Attributes.Gender).Must(y => y == "male" || y == "male").WithMessage("gender is one of male or female");
            RuleFor(i => i.DataD.Attributes.Gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(i => i.DataD.Attributes.Birthdate).NotEmpty().WithMessage("birhdate can't be empty");
            RuleFor(i => DateTime.Now.Year - i.DataD.Attributes.Birthdate.Year).GreaterThan(18).WithMessage("age must be greater than 18");
        }
    }
}