using AutoMapper;
using ECommerce.Application.Dtos.BrandDtos;
using MediatR;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.BrandCommandQuery.Queries.GetAllBrand
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQueryRequest, CustomResponseDto<List<BrandListDto>>>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBrandQueryHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<BrandListDto>>> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetAllAsync();

            var dto = _mapper.Map<List<BrandListDto>>(brands);

            return CustomResponseDto<List<BrandListDto>>.Success(200,dto);
        }
    }
}
