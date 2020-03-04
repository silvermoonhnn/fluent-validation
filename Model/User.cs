using System;

namespace FluentVal_Task.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RequestData<T>
    {
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T attributes { get; set; }
    }
}