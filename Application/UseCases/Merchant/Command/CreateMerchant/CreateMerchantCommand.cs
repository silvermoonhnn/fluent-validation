using System;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommand : IRequest<CreateMerchantCommandDto>
    {
        public CreateMerchantData Data { get; set; }
    }

    public class CreateMerchantData
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
    }
}