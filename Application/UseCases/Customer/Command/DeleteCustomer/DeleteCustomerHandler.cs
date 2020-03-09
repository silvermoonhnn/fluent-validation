
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandDto>
    {
        private readonly FluentContext _context;

        public DeleteCustomerCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<DeleteCustomerCommandDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Customers.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Customers.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteCustomerCommandDto { Message = "Successfull", Success = true };
        }
    }
}