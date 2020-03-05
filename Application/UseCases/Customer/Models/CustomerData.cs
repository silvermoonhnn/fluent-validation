using System;

namespace FluentVal_Task.Application.UseCases.Customer.Models
{
    public enum Gender { P, L }
    public class CustomerData
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }

    }
}