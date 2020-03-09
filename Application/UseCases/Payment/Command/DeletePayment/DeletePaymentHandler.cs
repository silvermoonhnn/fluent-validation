
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Payment.Command.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, DeletePaymentCommandDto>
    {
        private readonly FluentContext _context;

        public DeletePaymentCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<DeletePaymentCommandDto> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Payments.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Payments.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeletePaymentCommandDto { Message = "Successfull", Success = true };
        }
    }
}