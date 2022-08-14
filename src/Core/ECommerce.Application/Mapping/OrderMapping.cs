using AutoMapper;
using ECommerce.Application.Dtos.OrderDtos;
using ECommerce.Application.Features.OrderCommandQuery.Commands.AddOrder;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, AddOrderCommandRequest>().ReverseMap();
            CreateMap<Order, AddOrderDto>().ReverseMap();
            CreateMap<Order,OrderListDto>().ReverseMap();
        }
    }
}
