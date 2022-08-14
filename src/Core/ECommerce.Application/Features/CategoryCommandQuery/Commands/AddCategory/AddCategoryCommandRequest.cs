using MediatR;
using ECommerce.Application.Dtos.CategoryDtos;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.CategoryCommandQuery.Commands.AddCategory
{
    public class AddCategoryCommandRequest : IRequest<CustomResponseDto<AddCategoryDto>>
    {
        public string Name { get; set; }
    }
}
