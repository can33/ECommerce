using AutoMapper;
using ECommerce.Application.Dtos.BrandDtos;
using MediatR;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.BrandCommandQuery.Commands.AddBrand
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommandRequest, CustomResponseDto<AddBrandDto>>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public AddBrandCommandHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<AddBrandDto>> Handle(AddBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var createdBrand = _mapper.Map<Brand>(request);
            
            await _repository.CreateAsync(createdBrand);

            var dto = _mapper.Map<AddBrandDto>(createdBrand);

            return CustomResponseDto<AddBrandDto>.Success(200, dto);
            
        }
    }
}
