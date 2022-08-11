using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Dtos.CategoryDtos;
using ECommerce.Application.Features.CategoryCommandQuery.Commands.AddCategory;
using ECommerce.Application.Features.CategoryCommandQuery.Commands.UpdateCategory;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,CategoryListDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Category,AddCategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, CategoryForProductDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
        }
    }
}
