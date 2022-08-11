using Microsoft.EntityFrameworkCore;
using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;
using System.Collections;

namespace ECommerce.Persistance.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable> GetAllBrandWithProducts()
        {
            return await _context.Brands.Include(x => x.Products).ToListAsync();
        }
    }
}
