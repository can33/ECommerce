using ECommerce.Application.Features.CustomerCommandQuery.Commands.AddCustomer;
using ECommerce.Application.Features.CustomerCommandQuery.Commands.DeleteCustomer;
using ECommerce.Application.Features.CustomerCommandQuery.Queries.GetAllCustomer;
using ECommerce.Application.Features.CustomerCommandQuery.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CustomersController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _meditor.Send(new GetAllCustomerQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _meditor.Send(new GetCustomerByIdQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerCommandRequest request)
        {
            var response = await _meditor.Send(request);

            return StatusCode(201, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _meditor.Send(new RemoveCustomerCommandRequest(id));
            return NoContent();
        }
    }
}
