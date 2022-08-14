using AutoMapper;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.ProductCommandQuery.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, CustomResponseDto<List<ProductListDto>>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductListDto>>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllProductWithCategoryAndBrand();


            var dto = _mapper.Map<List<ProductListDto>>(products);

            return CustomResponseDto<List<ProductListDto>>.Success(200,dto);

        }
    }
}
