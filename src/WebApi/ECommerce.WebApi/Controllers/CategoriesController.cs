using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Features.CategoryCommandQuery.Commands.AddCategory;
using ECommerce.Application.Features.CategoryCommandQuery.Commands.RemoveCategory;
using ECommerce.Application.Features.CategoryCommandQuery.Commands.UpdateCategory;
using ECommerce.Application.Features.CategoryCommandQuery.Queries.GetAllCategory;
using ECommerce.Application.Features.CategoryCommandQuery.Queries.GetAllCategoryWithProducts;
using ECommerce.Application.Features.CategoryCommandQuery.Queries.GetCategoryById;
using ECommerce.Domain.Enums;

namespace ECommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles =UserRoles.Member)]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllCategoryQueryRequest()));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategoryWithProducts()
        {
            return Ok(await _mediator.Send(new GetAllCategoryWithProductsQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new RemoveCategoryCommandRequest(id)));
        }

    }
}
