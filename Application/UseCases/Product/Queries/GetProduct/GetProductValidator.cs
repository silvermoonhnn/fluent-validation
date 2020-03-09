using FluentValidation;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}