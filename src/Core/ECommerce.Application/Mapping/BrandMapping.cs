using AutoMapper;
using ECommerce.Application.Dtos.BrandDtos;
using ECommerce.Application.Dtos.BrandDtos;
using ECommerce.Application.Features.BrandCommandQuery.Commands.AddBrand;
using ECommerce.Application.Features.BrandCommandQuery.Commands.UpdateBrand;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mapping
{
    public class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<Brand, GetBrandByIdDto>().ReverseMap();
            CreateMap<Brand, AddBrandDto>().ReverseMap();
            CreateMap<Brand, AddBrandCommandRequest>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommandRequest>().ReverseMap();
            CreateMap<Brand, BrandListWithProductsDto>().ReverseMap();
            CreateMap<Brand, BrandForProductDto>().ReverseMap();
        }
    }
}
