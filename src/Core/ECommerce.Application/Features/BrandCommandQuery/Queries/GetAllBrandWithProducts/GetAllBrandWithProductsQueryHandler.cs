using AutoMapper;
using ECommerce.Application.Dtos.BrandDtos;
using MediatR;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.BrandCommandQuery.Queries.GetAllBrandWithProducts
{
    public class GetAllBrandWithProductsQueryHandler : IRequestHandler<GetAllBrandWithProductsQueryRequest, CustomResponseDto<List<BrandListWithProductsDto>>>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBrandWithProductsQueryHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<BrandListWithProductsDto>>> Handle(GetAllBrandWithProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetAllBrandWithProducts();

            var response = _mapper.Map<List<BrandListWithProductsDto>>(brands);

            return CustomResponseDto<List<BrandListWithProductsDto>>.Success(200, response);
        }
    }
}
