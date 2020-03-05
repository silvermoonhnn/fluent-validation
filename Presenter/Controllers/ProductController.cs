using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Infrastructure.Presistance;
using FluentVal_Task.Application.UseCases.Product.Queries.GetProduct;
using FluentVal_Task.Application.UseCases.Product.Queries.GetProducts;
using FluentVal_Task.Application.UseCases.Product.Command.CreateProduct;

namespace FluentVal_Task.Presenter.Controllers
{
    [ApiController]
    [Route("product")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IMediator _mediatr;
        // private readonly FluentContext _context;
        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public ProductController(FluentContext context)
        {
            // _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<GetProductsDto>> GetProducts()
        {
            return Ok(await Mediator.Send(new GetProductsQuery(){}));
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductCommandDto>> PostProduct([FromBody] CreateProductCommand payload)
        {
            return Ok(await Mediator.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDto>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetProductQuery() { Id = id}));
        }

        // [HttpPut("{id}")]
        // public IActionResult UpdateProduct(int id, ReqCus cu)
        // {
        //     var prod = _context.Products.First(i => i.Id == id);
        //     prod.Fullname = cu.data.attributes.Fullname;

        //     _context.Products.Update(prod);
        //     _context.SaveChanges();
        //     return Ok(prod);
        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteProduct(int id)
        // {
        //     var prod = _context.Products.First(i => i.Id == id);
        //     _context.Products.Remove(prod);
        //     _context.SaveChanges();
        //     return Ok(prod);
        // }
    }
}