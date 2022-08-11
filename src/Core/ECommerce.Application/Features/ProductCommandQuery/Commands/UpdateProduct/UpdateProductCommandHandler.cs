using AutoMapper;
using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.ProductCommandQuery.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, CustomResponseDto<NoContentDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<NoContentDto>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var updatedProduct = _mapper.Map<Product>(request);

            await _repository.UpdateAsync(updatedProduct);

            return CustomResponseDto<NoContentDto>.Success(204);





        }
    }
}
