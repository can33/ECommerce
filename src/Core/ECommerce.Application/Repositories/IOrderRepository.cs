using ECommerce.Application.Interfaces.Repository;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Repositories
{
    public interface IOrderRepository : IGenericRepositoryAsync<Order>
    {
        Task<IEnumerable<Order>> GetAllOrderWithProducts();
        Task AddAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersById();
    }
}
