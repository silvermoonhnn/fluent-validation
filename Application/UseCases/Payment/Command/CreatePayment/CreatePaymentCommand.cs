using System;
using FluentVal_Task.Domain.Entities;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommand : IRequest<CreatePaymentCommandDto>
    {
        public CreatePaymentData Data { get; set; }
    }

    public class CreatePaymentData
    {
        public int Customer_Id { get; set; }
        public string NameOnCard { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public int PostalCode { get; set; }
        public string CreditCardNum { get; set; }
    }
}