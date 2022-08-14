using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                Products = new List<Product>() { product },
                CustomerId = order.CustomerId,
                Address = order.Address,

            });
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Order>> GetAllOrderWithProducts()
        {
            return await _context.Orders.Include(x => x.Products).ToListAsync();
            
        }

        public async Task<IEnumerable<Order>> GetOrdersById()
        {
            var pro = await _context.Orders.Include(x => x.Products).Select(x=>x.Products).ToListAsync();

            var result = await _context.Orders.Include(x=>x.Products).GroupBy(x => x.Id).Select(group => new Order
            {
                Id = group.Key
                
            }).ToListAsync() ;

            return result;   
        }
    }
}
