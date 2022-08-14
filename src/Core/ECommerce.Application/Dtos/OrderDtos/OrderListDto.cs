using ECommerce.Application.Dtos.ProductDtos;

namespace ECommerce.Application.Dtos.OrderDtos
{
    public class OrderListDto
    {
        public Guid Id { get; set; }
        public ICollection<ProductForOrderDto> Products { get; set; }
        public string Address { get; set; }
        public Guid CustomerId { get; set; }
    }
}
