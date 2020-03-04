using Microsoft.AspNetCore.Mvc;
using FluentVal_Task.Entities;
using System.Linq;

namespace FluentVal_Task.Presenter.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly FluentContext _context;
        public CustomerController(FluentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var cu = _context.Customers;
            return Ok(new {message = "success retrieve data", status = true, data = cu});
        }

        [HttpPost]
        public IActionResult PostCustomer(ReqCus customer)
        {
            _context.Customers.Add(customer.data.attributes);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.First(i => i.Id == id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, ReqCus cu)
        {
            var customer = _context.Customers.First(i => i.Id == id);
            customer.Fullname = cu.data.attributes.Fullname;

            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.First(i => i.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
    }

    public class ReqCus
    {
        public Cus data { get; set; }
    }

    public class Cus
    {
        public Customer attributes { get; set; }
    }
}