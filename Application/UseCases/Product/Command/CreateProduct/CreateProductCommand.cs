using System;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandDto>
    {
        public CreateProductData Data { get; set; }
    }

    public class CreateProductData
    {
        public int Merchant_Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}