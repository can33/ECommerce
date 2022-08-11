using Microsoft.EntityFrameworkCore;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoryWithProducts()
        {
            return await _context.Categories.Include(x=>x.Products).AsNoTracking().ToListAsync();
        }
    }
}
