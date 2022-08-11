using MediatR;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.ProductCommandQuery.Commands.AddProduct
{
    public class AddProductCommandRequest : IRequest<CustomResponseDto<AddProductDto>>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
    }
}
