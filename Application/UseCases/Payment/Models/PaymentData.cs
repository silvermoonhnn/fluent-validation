using System;

namespace FluentVal_Task.Application.UseCases.Payment.Models
{
    public class PaymentData
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string NameOnCard { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
        public int PostalCode { get; set; }
        public string CreditCardNum { get; set; }
    }
}