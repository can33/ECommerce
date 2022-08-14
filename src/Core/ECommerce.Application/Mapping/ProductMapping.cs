using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Features.ProductCommandQuery.Commands.AddProduct;
using ECommerce.Application.Features.ProductCommandQuery.Commands.UpdateProduct;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ProductListDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product,AddProductCommandRequest>().ReverseMap();
            CreateMap<Product,UpdateProductCommandRequest>().ReverseMap();
            CreateMap<Product,ProductForCategoryDto>().ReverseMap();
            CreateMap<Product,ProductForBrandDto>().ReverseMap();
            CreateMap<Product,ProductForOrderDto>().ReverseMap();

        }
    }
}
