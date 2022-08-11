using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Features.ProductCommandQuery.Commands.AddProduct;
using ECommerce.Application.Features.ProductCommandQuery.Commands.RemoveProduct;
using ECommerce.Application.Features.ProductCommandQuery.Commands.UpdateProduct;
using ECommerce.Application.Features.ProductCommandQuery.Queries.GetAllProduct;
using ECommerce.Application.Features.ProductCommandQuery.Queries.GetProductById;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllProductQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQueryRequest() { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Ok(await _mediator.Send(new RemoveProductCommandRequest { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
