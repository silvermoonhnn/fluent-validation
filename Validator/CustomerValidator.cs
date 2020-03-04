using System;
using FluentValidation;
using FluentVal_Task.Entities;

namespace FluentVal_Task.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(x => x.Email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.Birthdate).NotEmpty().WithMessage("birhdate can't be empty");
            RuleFor(x => DateTime.Now.Year - x.Birthdate.Year).GreaterThan(18).WithMessage("age must be greater than 18");
        }   
    }
}