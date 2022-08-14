using AutoMapper;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Dtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.CustomerCommandQuery.Commands.DeleteCustomer
{
    public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommandRequest, CustomResponseDto<NoContentDto>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public RemoveCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<NoContentDto>> Handle(RemoveCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedCustomer = await _repository.GetByIdAsync(request.Id);
            
            if (deletedCustomer == null)
                throw new NotFoundException($"Customer is not found");

            await _repository.RemoveAsync(deletedCustomer);

            return CustomResponseDto<NoContentDto>.Success(204);
        }
    }
}
