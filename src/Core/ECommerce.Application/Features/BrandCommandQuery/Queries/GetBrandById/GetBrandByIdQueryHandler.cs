using AutoMapper;
using MediatR;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Dtos.BrandDtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.BrandCommandQuery.Queries.GetBrandById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQueryRequest, CustomResponseDto<GetBrandByIdDto>>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetBrandByIdDto>> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var brand = await _repository.GetByFilterAsync(x=>x.Id == request.Id);
            
            if (brand is null)
                throw new NotFoundException($"Brand is not found");
            
            var dto = _mapper.Map<GetBrandByIdDto>(brand);

            return CustomResponseDto<GetBrandByIdDto>.Success(200,dto);
        }
    }
}
