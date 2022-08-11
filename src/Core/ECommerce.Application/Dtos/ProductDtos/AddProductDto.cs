using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.ProductDtos
{
    public class AddProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
    }
}
