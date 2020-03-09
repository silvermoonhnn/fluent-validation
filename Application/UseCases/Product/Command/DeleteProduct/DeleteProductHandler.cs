
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Product.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandDto>
    {
        private readonly FluentContext _context;

        public DeleteProductCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<DeleteProductCommandDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Products.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Products.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteProductCommandDto { Message = "Successfull", Success = true };
        }
    }
}