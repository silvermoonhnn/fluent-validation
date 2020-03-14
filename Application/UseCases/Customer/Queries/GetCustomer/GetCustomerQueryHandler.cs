using System;
using System.ComponentModel;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentVal_Task.Infrastructure.Presistance;
using Hangfire;
using MimeKit;
using MailKit.Net.Smtp;

namespace FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
         private readonly FluentContext _context;

         public GetCustomerQueryHandler(FluentContext context)
         {
             _context = context;
         }

         public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellation)
         {
            BackgroundJob.Enqueue(() => Console.WriteLine("Someone's requesting and getting a data"));
            
            var result = await _context.Customers.FirstOrDefaultAsync( i => i.Id == request.Id);
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
                    Text = @"You're requesting and getting a customer data."
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

                return new GetCustomerDto
                {
                    Success = true,
                    Message = "Customer successfully retrieved",
                    Data = result
                };
            }
         }
    }
}