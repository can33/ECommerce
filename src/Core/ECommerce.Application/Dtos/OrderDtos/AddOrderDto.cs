using ECommerce.Application.Dtos.CustomerDtos;
using ECommerce.Application.Dtos.ProductDtos;

namespace ECommerce.Application.Dtos.OrderDtos
{
    public class AddOrderDto
    {
        public ICollection<ProductForAddOrderDto> Products { get; set; }
        public Guid CustomerId { get; set; }
        public string Address { get; set; }
    }
}
