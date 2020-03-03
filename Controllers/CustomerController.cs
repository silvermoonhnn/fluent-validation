using Microsoft.AspNetCore.Mvc;
using FluentVal_Task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FluentVal_Task.Controllers
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
        public IActionResult PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
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
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _context.Customers.First(i => i.Id == id);
            customer.Fullname = "Bonnana Boat";
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
}