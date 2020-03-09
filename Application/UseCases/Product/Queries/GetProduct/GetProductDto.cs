using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductDto : BaseDto
    {
        public ProductEn Data { get; set; }
    }
}