using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Application.Interfaces;
using FluentVal_Task.Infrastructure.Presistance;
using Hangfire;
using MimeKit;
using MailKit.Net.Smtp;
using System;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDto>
    {
        private readonly FluentContext _context;

        public GetMerchantQueryHandler(FluentContext context)
        {
            _context = context;
        }

        public async Task<GetMerchantDto> Handle(GetMerchantQuery request, CancellationToken cancellation)
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Someone's requesting and getting a data"));
             
            var result = await _context.Merchants.FirstOrDefaultAsync( i => i.Id == request.Id);
             
            if (result == null)
            {
                return null;
            }
            else
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Another background h", "whatisbackgroundh@gmail.com"));
                message.To.Add(new MailboxAddress("Another backgrounf a", "whatisbackgrounda@gmail.com"));
                message.Subject = "Requesting a data";

                message.Body = new TextPart("plain")
                {
                    Text = @"You're requesting and getting a merchant data."
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.mailtrap.io", 2525, false);
                    client.Authenticate("b0549629350b6a", "b4ff41cb5cfb79");

                    client.Send(message);
                    client.Disconnect(true);
                    Console.WriteLine("E-mail Sent");
                }

                return new GetMerchantDto
                {
                    Success = true,
                    Message = "Merchant successfully retrieved",
                    Data = result
                };
            }
        }
    }
}