using FluentVal_Task.Application.UseCases.Product.Models;
using FluentVal_Task.Application.Models.Query;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductDto : BaseDto
    {
        public ProductData Data { get; set; }
    }
}