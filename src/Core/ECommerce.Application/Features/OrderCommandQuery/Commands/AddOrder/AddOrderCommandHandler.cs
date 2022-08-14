using AutoMapper;
using ECommerce.Application.Dtos.OrderDtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.OrderCommandQuery.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, CustomResponseDto<AddOrderDto>>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public AddOrderCommandHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<AddOrderDto>> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
           
            var addedOrder = _mapper.Map<Order>(request);

            await _repository.AddAsync(addedOrder);

            var response = _mapper.Map<AddOrderDto>(addedOrder);

            return CustomResponseDto<AddOrderDto>.Success(201,response);
        }
    }
}
