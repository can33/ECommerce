using ECommerce.Application.Dtos.BrandDtos;
using ECommerce.Application.Dtos.CategoryDtos;

namespace ECommerce.Application.Dtos.ProductDtos
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public CategoryForProductDto Category { get; set; }
        public BrandForProductDto Brand { get; set; }
    }
}
