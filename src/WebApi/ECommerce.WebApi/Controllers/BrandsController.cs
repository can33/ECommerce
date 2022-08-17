using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Features.BrandCommandQuery.Commands.AddBrand;
using ECommerce.Application.Features.BrandCommandQuery.Commands.DeleteBrand;
using ECommerce.Application.Features.BrandCommandQuery.Commands.UpdateBrand;
using ECommerce.Application.Features.BrandCommandQuery.Queries.GetAllBrand;
using ECommerce.Application.Features.BrandCommandQuery.Queries.GetAllBrandWithProducts;
using ECommerce.Application.Features.BrandCommandQuery.Queries.GetBrandById;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllBrandQueryRequest()));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBrandWithProducts()
        {
            return Ok(await _mediator.Send(new GetAllBrandWithProductsQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetBrandByIdQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBrandCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(201,response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _mediator.Send(new DeleteBrandCommandRequest(id));
            return NoContent();
        }

    }
}
