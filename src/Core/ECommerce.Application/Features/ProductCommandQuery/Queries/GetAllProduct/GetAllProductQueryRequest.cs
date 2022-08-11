using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.ProductCommandQuery.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<CustomResponseDto<List<ProductListDto>>>
    {   
    }
}
