using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.BrandCommandQuery.Commands.DeleteBrand
{
    public class DeleteBrandCommandRequest : IRequest<CustomResponseDto<NoContentDto>>
    {
        public Guid Id { get; set; }

        public DeleteBrandCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
