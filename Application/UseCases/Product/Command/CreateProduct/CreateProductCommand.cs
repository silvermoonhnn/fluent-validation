using System;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommand : RequestData<ProductEn> ,IRequest<CreateProductCommandDto>
    {
        
    }
}