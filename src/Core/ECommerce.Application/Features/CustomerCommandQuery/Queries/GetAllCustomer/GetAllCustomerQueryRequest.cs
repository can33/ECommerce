using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.CustomerCommandQuery.Queries.GetAllCustomer
{
    public class GetAllCustomerQueryRequest : IRequest<CustomResponseDto<List<CustomerListDto>>>
    {
    }
}
