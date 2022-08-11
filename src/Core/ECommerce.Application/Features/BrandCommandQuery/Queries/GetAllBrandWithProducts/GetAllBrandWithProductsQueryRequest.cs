using ECommerce.Application.Dtos.BrandDtos;
using MediatR;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.BrandCommandQuery.Queries.GetAllBrandWithProducts
{
    public class GetAllBrandWithProductsQueryRequest : IRequest<CustomResponseDto<List<BrandListWithProductsDto>>>
    {
    }
}
