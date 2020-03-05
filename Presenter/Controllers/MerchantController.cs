using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchant;
using FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchants;
using FluentVal_Task.Application.UseCases.Merchant.Command.CreateMerchant;

namespace FluentVal_Task.Presenter.Controllers
{
    [ApiController]
    [Route("merchant")]
    public class MerchantController : ControllerBase
    {
        private IMediator _mediatr;
        // private readonly FluentContext _context;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public MerchantController(FluentContext context)
        {
            // _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<GetMerchantsDto>> GetMerchants()
        {
            return Ok(await Mediator.Send(new GetMerchantsQuery(){}));
        }

        [HttpPost]
        public async Task<ActionResult<CreateMerchantCommandDto>> PostMerchant([FromBody] CreateMerchantCommand payload)
        {
            return Ok(await Mediator.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMerchantDto>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetMerchantQuery() { Id = id}));
        }

        // [HttpPut("{id}")]
        // public IActionResult UpdateMerchant(int id, ReqCus cu)
        // {
        //     var merchant = _context.Merchants.First(i => i.Id == id);
        //     merchant.Fullname = cu.data.attributes.Fullname;

        //     _context.Merchants.Update(merchant);
        //     _context.SaveChanges();
        //     return Ok(merchant);
        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteMerchant(int id)
        // {
        //     var merchant = _context.Merchants.First(i => i.Id == id);
        //     _context.Merchants.Remove(merchant);
        //     _context.SaveChanges();
        //     return Ok(merchant);
        // }
    }
}