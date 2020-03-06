using System;

namespace FluentVal_Task.Domain.Entities
{
    public class MerchantEn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imamge { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}