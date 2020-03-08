using System;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommand : RequestData<MerchantEn> , IRequest<CreateMerchantCommandDto>
    {
        
    }
}