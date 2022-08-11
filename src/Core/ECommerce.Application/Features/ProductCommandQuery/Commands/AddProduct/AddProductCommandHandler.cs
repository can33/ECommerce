using AutoMapper;
using MediatR;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.ProductCommandQuery.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, CustomResponseDto<AddProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<AddProductDto>> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var addedProduct = _mapper.Map<Product>(request);

            await _repository.CreateAsync(addedProduct);

            var response = _mapper.Map<AddProductDto>(addedProduct);

            return CustomResponseDto<AddProductDto>.Success(201, response);
        }
    }
}
