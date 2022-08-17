using ECommerce.Application.Features.OrderCommandQuery.Commands.AddOrder;
using ECommerce.Application.Features.OrderCommandQuery.Queries.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllOrderQueryRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(201,response);
        }
    }
}
