using AutoMapper;
using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CustomerCommandQuery.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, CustomResponseDto<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public AddCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CustomerDto>> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var addedCustomer = _mapper.Map<Customer>(request);
            
            await _repository.CreateAsync(addedCustomer);

            var response = _mapper.Map<CustomerDto>(addedCustomer);
            
            return CustomResponseDto<CustomerDto>.Success(201,response);
        }
    }
}
