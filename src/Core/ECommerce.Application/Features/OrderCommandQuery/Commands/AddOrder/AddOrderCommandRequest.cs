using ECommerce.Application.Dtos.OrderDtos;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.OrderCommandQuery.Commands.AddOrder
{
    public class AddOrderCommandRequest : IRequest<CustomResponseDto<AddOrderDto>>
    {
        public List<ProductForOrderDto> Products { get; set; }
    }
}
