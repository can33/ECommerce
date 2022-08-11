using AutoMapper;
using MediatR;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Dtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;

namespace ECommerce.Application.Features.ProductCommandQuery.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest,CustomResponseDto<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<CustomResponseDto<ProductDto>> IRequestHandler<GetProductByIdQueryRequest, CustomResponseDto<ProductDto>>.Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByFilterAsync(x=>x.Id == request.Id);

            if (product is null)
                throw new NotFoundException($"Product is not found");
           
            var dto = _mapper.Map<ProductDto>(product);
           
            return CustomResponseDto<ProductDto>.Success(200,dto);
        }
    }
}
