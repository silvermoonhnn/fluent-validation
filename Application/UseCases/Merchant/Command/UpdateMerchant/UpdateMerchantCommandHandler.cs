using System;
using System.Threading;
using System.Threading.Tasks;
using FluentVal_Task.Application.Interfaces;
using MediatR;


namespace FluentVal_Task.Application.UseCases.Merchant.Command.UpdateMerchant
{
    public class UpdateMerchantCommandHandler : IRequestHandler<UpdateMerchantCommand, UpdateMerchantCommandDto>
    {
        private readonly ICommandContext _context;
        
        public UpdateMerchantCommandHandler(ICommandContext context)
        {
            _context = context;
        }

        public async Task<UpdateMerchantCommandDto> Handle(UpdateMerchantCommand request, CancellationToken cancellation)
        {
            var merchant = _context.Merchants.Find(request.DataD.Attributes.Id);

            merchant.Name = request.DataD.Attributes.Name;
            merchant.Imamge = request.DataD.Attributes.Imamge;
            merchant.Address = request.DataD.Attributes.Address;
            merchant.Rating = request.DataD.Attributes.Rating;

            await _context.SaveChangesAsync(cancellation);

            return new UpdateMerchantCommandDto
            {
                Success = true,
                Message = "Merchant successfully updated"
            };
        }
    }
}