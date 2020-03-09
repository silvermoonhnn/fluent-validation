using System;
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;


namespace FluentVal_Task.Application.UseCases.Product.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandDto>
    {
        private readonly FluentContext _context;
        
        public UpdateProductCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductCommandDto> Handle(UpdateProductCommand request, CancellationToken cancellation)
        {
            var product = _context.Products.Find(request.DataD.Attributes.Id);
            
            product.Merchant_Id = request.DataD.Attributes.Merchant_Id;
            product.Name = request.DataD.Attributes.Name;
            product.Price = request.DataD.Attributes.Price;

            await _context.SaveChangesAsync(cancellation);

            return new UpdateProductCommandDto
            {
                Success = true,
                Message = "Payment successfully updated"
            };
        }
    }
}