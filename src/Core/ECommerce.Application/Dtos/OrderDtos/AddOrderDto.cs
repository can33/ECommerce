using ECommerce.Application.Dtos.ProductDtos;

namespace ECommerce.Application.Dtos.OrderDtos
{
    public class AddOrderDto
    {
        public ICollection<ProductForOrderDto> Products { get; set; }
    }
}
