using System.ComponentModel.DataAnnotations;
using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;

namespace FluentVal_Task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandDto>
    {
        private readonly FluentContext _context;

        public CreateProductCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<CreateProductCommandDto> Handle(CreateProductCommand request, CancellationToken cancellation)
        {
            var prod = new Domain.Entities.Product
            {
                Merchant_Id = request.Data.Merchant_Id,
                Name = request.Data.Name,
                Price = request.Data.Price
            };

            _context.Products.Add(prod);
            await _context.SaveChangesAsync(cancellation);

            return new CreateProductCommandDto
            {
                Success = true,
                Message = "Product successfully created"
            };

        }
    }
}