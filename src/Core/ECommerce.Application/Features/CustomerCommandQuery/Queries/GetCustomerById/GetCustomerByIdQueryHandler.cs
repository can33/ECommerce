using AutoMapper;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.CustomerCommandQuery.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest, CustomResponseDto<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CustomerDto>> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {

            var customer = await _repository.GetByFilterAsync(x => x.Id == request.Id);

            if (customer is null)
                throw new NotFoundException($"Customer is not found");

            var response = _mapper.Map<CustomerDto>(customer);

            return CustomResponseDto<CustomerDto>.Success(200,response);
        }
    }
}
