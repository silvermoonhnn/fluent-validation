
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Merchant.Command.UpdateMerchant
{
    public class UpdateMerchantCommand : RequestData<MerchantEn>, IRequest<UpdateMerchantCommandDto>
    {
        
    }
}