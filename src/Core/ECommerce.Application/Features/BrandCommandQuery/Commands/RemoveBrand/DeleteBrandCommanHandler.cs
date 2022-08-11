using AutoMapper;
using MediatR;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Dtos;
using ECommerce.Application.Features.BrandCommandQuery.Commands.DeleteBrand;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.BrandCommandQuery.Commands.RemoveBrand
{
    public class DeleteBrandCommanHandler : IRequestHandler<DeleteBrandCommandRequest, CustomResponseDto<NoContentDto>>
    {
        private readonly IBrandRepository _repository;

        public DeleteBrandCommanHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<CustomResponseDto<NoContentDto>> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedBrand = await _repository.GetByIdAsync(request.Id);

            if (deletedBrand is null)
                throw new NotFoundException($"Brand is not found");

            await _repository.RemoveAsync(deletedBrand);

            return CustomResponseDto<NoContentDto>.Success(204);
        }

       
    }
}
