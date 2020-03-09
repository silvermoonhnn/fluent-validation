
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Product.Command.UpdateProduct
{
    public class UpdateProductCommand : RequestData<ProductEn>,IRequest<UpdateProductCommandDto>
    {
        
    }
}