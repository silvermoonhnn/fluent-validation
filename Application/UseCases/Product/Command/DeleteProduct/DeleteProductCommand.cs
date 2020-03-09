
using MediatR;

namespace FluentVal_Task.Application.UseCases.Product.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandDto>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}