using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.ProductCommandQuery.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<CustomResponseDto<List<ProductListDto>>>
    {   
    }
}
