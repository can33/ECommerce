using AutoMapper;
using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CustomerCommandQuery.Queries.GetAllCustomer
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, CustomResponseDto<List<CustomerListDto>>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CustomerListDto>>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customers =await _repository.GetAllAsync();

            var response = _mapper.Map<List<CustomerListDto>>(customers);

            return CustomResponseDto<List<CustomerListDto>>.Success(200,response);
        }
    }
}
