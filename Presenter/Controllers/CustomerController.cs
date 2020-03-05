using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomer;
using FluentVal_Task.Application.UseCases.Customer.Queries.GetCustomers;
using FluentVal_Task.Application.UseCases.Customer.Command.CreateCustomer;

namespace FluentVal_Task.Presenter.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;
        // private readonly FluentContext _context;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public CustomerController(FluentContext context)
        {
            // _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersDto>> GetCustomers()
        {
            return Ok(await Mediator.Send(new GetCustomersQuery(){}));
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerCommandDto>> PostCustomer([FromBody] CreateCustomerCommand payload)
        {
            return Ok(await Mediator.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerDto>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerQuery() { Id = id}));
        }

        // [HttpPut("{id}")]
        // public IActionResult UpdateCustomer(int id, ReqCus cu)
        // {
        //     var customer = _context.Customers.First(i => i.Id == id);
        //     customer.Fullname = cu.data.attributes.Fullname;

        //     _context.Customers.Update(customer);
        //     _context.SaveChanges();
        //     return Ok(customer);
        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteCustomer(int id)
        // {
        //     var customer = _context.Customers.First(i => i.Id == id);
        //     _context.Customers.Remove(customer);
        //     _context.SaveChanges();
        //     return Ok(customer);
        // }
    }
}