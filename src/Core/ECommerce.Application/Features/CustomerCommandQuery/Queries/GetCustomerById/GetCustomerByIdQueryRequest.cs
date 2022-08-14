using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.CustomerCommandQuery.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryRequest : IRequest<CustomResponseDto<CustomerDto>>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
