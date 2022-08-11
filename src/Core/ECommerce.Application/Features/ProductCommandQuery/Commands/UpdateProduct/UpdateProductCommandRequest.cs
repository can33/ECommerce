using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.ProductCommandQuery.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<CustomResponseDto<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}
