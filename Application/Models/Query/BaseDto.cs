namespace FluentVal_Task.Application.Models.Query
{
    public abstract class BaseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}