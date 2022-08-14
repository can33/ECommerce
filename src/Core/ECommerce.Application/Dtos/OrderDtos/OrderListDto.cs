using ECommerce.Domain.Entities;

namespace ECommerce.Application.Dtos.OrderDtos
{
    public class OrderListDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
