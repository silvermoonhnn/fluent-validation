using System;

namespace FluentVal_Task.Application.UseCases.Merchant.Models
{
    public class MerchantData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }

    }
}