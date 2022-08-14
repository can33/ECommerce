using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.ProductCommandQuery.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<CustomResponseDto<ProductDto>>
    {
        public Guid Id { get; set; }
    }
}
