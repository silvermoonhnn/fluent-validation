using System.ComponentModel.DataAnnotations;
using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;

namespace FluentVal_Task.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, CreateMerchantCommandDto>
    {
        private readonly FluentContext _context;

        public CreateMerchantCommandHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<CreateMerchantCommandDto> Handle(CreateMerchantCommand request, CancellationToken cancellation)
        {
            var merchant = new Domain.Entities.MerchantEn
            {
                Name = request.Data.Name,
                Imamge = request.Data.Imamge,
                Address = request.Data.Address,
                Rating = request.Data.Rating
            };

            _context.Merchants.Add(merchant);
            await _context.SaveChangesAsync(cancellation);

            return new CreateMerchantCommandDto
            {
                Success = true,
                Message = "Merchant successfully created"
            };

        }
    }
}