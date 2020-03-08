using System;

namespace FluentVal_Task.Domain.Entities
{
    public enum Gender
    {
        Male, Female   
    }
    
    public class CustomerEn
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Sex { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}