using AutoMapper;
using ECommerce.Application.Dtos.OrderDtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.OrderCommandQuery.Queries.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, CustomResponseDto<List<OrderListDto>>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<OrderListDto>>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllOrderWithProducts();             

            var response = _mapper.Map<List<OrderListDto>>(orders);

            return CustomResponseDto<List<OrderListDto>>.Success(200,response);
        }
    }
}
