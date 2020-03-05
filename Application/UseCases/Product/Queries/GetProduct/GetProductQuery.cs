using MediatR;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public int Id { get; set; }
    }
}