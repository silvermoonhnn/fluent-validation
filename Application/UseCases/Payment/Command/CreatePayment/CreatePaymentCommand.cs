using System;
using FluentVal_Task.Application.Models.Query;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommand : RequestData<PaymentEn> , IRequest<CreatePaymentCommandDto>
    {
        
    }
}