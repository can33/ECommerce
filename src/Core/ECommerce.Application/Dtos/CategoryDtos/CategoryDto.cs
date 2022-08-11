using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Defination { get; set; }
        public List<ProductForCategoryDto> Products { get; set; }
    }
}
