using System.Collections.Generic;
using FluentVal_Task.Application.UseCases.Product.Models;
using FluentVal_Task.Application.Models.Query;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsDto : BaseDto
    {
        public IList<ProductData> Data { get; set; }
    }
}