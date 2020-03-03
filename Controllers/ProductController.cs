using Microsoft.AspNetCore.Mvc;
using FluentVal_Task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FluentVal_Task.Controllers
{
    [ApiController]
    [Route("product")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly FluentContext _context;
        public ProductController(FluentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            var po = _context.Products;
            return Ok(new {message = "success retrieve data", status = true, data = po});
        }

        [HttpPost]
        public IActionResult PostProduct(Product po)
        {
            _context.Products.Add(po);
            _context.SaveChanges();
            return Ok(po);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var po = _context.Products.First(i => i.Id == id);
            return Ok(po);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            var po = _context.Products.First(i => i.Id == id);
            po.Name = "Banana";
            _context.SaveChanges();
            return Ok(po);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var po = _context.Products.First(i => i.Id == id);
            _context.Products.Remove(po);
            _context.SaveChanges();
            return Ok(po);
        }
    }
}