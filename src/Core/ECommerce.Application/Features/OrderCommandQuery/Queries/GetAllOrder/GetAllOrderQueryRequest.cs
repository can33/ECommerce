using ECommerce.Application.Dtos.OrderDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.OrderCommandQuery.Queries.GetAllOrder
{
    public class GetAllOrderQueryRequest : IRequest<CustomResponseDto<List<OrderListDto>>>
    {
    }
}
