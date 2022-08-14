using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.CustomerCommandQuery.Commands.DeleteCustomer
{
    public class RemoveCustomerCommandRequest : IRequest<CustomResponseDto<NoContentDto>>
    {
        public Guid Id { get; set; }

        public RemoveCustomerCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
