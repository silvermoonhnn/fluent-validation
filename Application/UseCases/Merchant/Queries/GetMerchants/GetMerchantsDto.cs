using System.Collections.Generic;
using FluentVal_Task.Application.UseCases.Merchant.Models;
using FluentVal_Task.Application.Models.Query;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsDto : BaseDto
    {
        public IList<MerchantData> Data { get; set; }
    }
}