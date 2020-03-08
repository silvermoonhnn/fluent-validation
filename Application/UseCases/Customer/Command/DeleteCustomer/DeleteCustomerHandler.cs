
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Application.Interfaces;
using MediatR;

namespace FluentVal_Task.Application.UseCases.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandDto>
    {
        private readonly ICommandContext _context;

        public DeleteCustomerCommandHandler(ICommandContext context)
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