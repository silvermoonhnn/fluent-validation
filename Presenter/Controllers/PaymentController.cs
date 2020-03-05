using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Payment.Queries.GetPayment;
using FluentVal_Task.Application.UseCases.Payment.Queries.GetPayments;
using FluentVal_Task.Application.UseCases.Payment.Command.CreatePayment;

namespace FluentVal_Task.Presenter.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediatr;
        // private readonly FluentContext _context;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public PaymentController(FluentContext context)
        {
            // _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<GetPaymentsDto>> GetPayments()
        {
            return Ok(await Mediator.Send(new GetPaymentsQuery(){}));
        }

        [HttpPost]
        public async Task<ActionResult<CreatePaymentCommandDto>> PostPayment([FromBody] CreatePaymentCommand payload)
        {
            return Ok(await Mediator.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPaymentDto>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPaymentQuery() { Id = id}));
        }

        // [HttpPut("{id}")]
        // public IActionResult UpdatePayment(int id, ReqCus cu)
        // {
        //     var payment = _context.Payments.First(i => i.Id == id);
        //     payment.Fullname = cu.data.attributes.Fullname;

        //     _context.Payments.Update(payment);
        //     _context.SaveChanges();
        //     return Ok(payment);
        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteMerchant(int id)
        // {
        //     var payment = _context.Payments.First(i => i.Id == id);
        //     _context.Payments.Remove(payment);
        //     _context.SaveChanges();
        //     return Ok(payment);
        // }
    }
}