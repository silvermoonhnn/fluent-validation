using System.Collections.Generic;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsDto : BaseDto
    {
        public IList<ProductEn> Data { get; set; }
    }
}