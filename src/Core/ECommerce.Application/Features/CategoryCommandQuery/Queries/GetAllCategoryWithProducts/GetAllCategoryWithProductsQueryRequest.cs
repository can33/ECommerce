using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.CategoryCommandQuery.Queries.GetAllCategoryWithProducts
{
    public class GetAllCategoryWithProductsQueryRequest : IRequest<CustomResponseDto<List<CategoryDto>>>
    {
    }
}
