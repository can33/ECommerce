using MediatR;
using ECommerce.Application.Dtos.BrandDtos;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.BrandCommandQuery.Queries.GetBrandById
{
    public class GetBrandByIdQueryRequest : IRequest<CustomResponseDto<GetBrandByIdDto>>
    {
        public Guid Id { get; set; }

        public GetBrandByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
