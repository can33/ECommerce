using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Dtos.OrderDtos;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.OrderCommandQuery.Commands.AddOrder
{
    public class AddOrderCommandRequest : IRequest<CustomResponseDto<AddOrderDto>>
    {
        public string Address { get; set; }
        public List<ProductForAddOrderDto> Products { get; set; }
        public Guid CustomerId { get; set; }
    }
}
