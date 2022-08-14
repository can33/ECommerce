using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.CustomerCommandQuery.Commands.AddCustomer
{
    public class AddCustomerCommandRequest : IRequest<CustomResponseDto<CustomerDto>>
    {
        public string Name { get; set; }
    }
}
