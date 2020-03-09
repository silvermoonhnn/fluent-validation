
using MediatR;

namespace FluentVal_Task.Application.UseCases.Payment.Command.DeletePayment
{
    public class DeletePaymentCommand : IRequest<DeletePaymentCommandDto>
    {
        public int Id { get; set; }

        public DeletePaymentCommand(int id)
        {
            Id = id;
        }
    }
}