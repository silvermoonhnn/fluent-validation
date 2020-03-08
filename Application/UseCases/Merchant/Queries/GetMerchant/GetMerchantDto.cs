using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantDto : BaseDto
    {
        public MerchantEn Data { get; set; }
    }
}