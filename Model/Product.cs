using System;

namespace FluentVal_Task.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Merchant_Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

