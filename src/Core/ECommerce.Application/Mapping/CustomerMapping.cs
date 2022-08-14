using AutoMapper;
using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Features.CustomerCommandQuery.Commands.AddCustomer;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer, CustomerForOrderDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, AddCustomerCommandRequest>().ReverseMap();
            CreateMap<Customer, CustomerListDto>().ReverseMap();
        }
    }
}
