using FluentVal_Task.Application.UseCases.Merchant.Models;
using FluentVal_Task.Application.Models.Query;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantDto : BaseDto
    {
        public MerchantData Data { get; set; }
    }
}