using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistance.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Order order)
        {
            Guid id = Guid.Empty;

            foreach (var item in order.Products)
            {
                id = item.Id;
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            await _context.Orders.AddAsync(new Order
            {
                Products = new List<Product>() { product }

            });
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Order>> GetAllOrderWithProducts()
        {
            return await _context.Orders.Include(x => x.Products).ToListAsync();
            
        }
    }
}
