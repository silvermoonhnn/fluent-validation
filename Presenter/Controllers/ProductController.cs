using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using FluentVal_Task.Application.UseCases.Product.Queries.GetProduct;
using FluentVal_Task.Application.UseCases.Product.Queries.GetProducts;
using FluentVal_Task.Application.UseCases.Product.Command.CreateProduct;
using FluentVal_Task.Application.UseCases.Product.Command.UpdateProduct;
using FluentVal_Task.Application.UseCases.Product.Command.DeleteProduct;

namespace FluentVal_Task.Presenter.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediatr;
        // protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetProductsDto>> GetProducts()
        {
            return Ok(await _mediatr.Send(new GetProductsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductCommandDto>> PostProduct([FromBody] CreateProductCommand payload)
        {
            return Ok(await _mediatr.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDto>> GetById(int id)
        {
            return Ok(await _mediatr.Send(new GetProductQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand data)
        {
            data.DataD.Attributes.Id = id;

            return Ok(await _mediatr.Send(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }
        
    }
}