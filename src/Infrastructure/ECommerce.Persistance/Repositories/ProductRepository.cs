using Microsoft.EntityFrameworkCore;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductWithCategoryAndBrand()
        {
            return await _context.Products.Include(x=>x.Category).Include(x=>x.Brand).AsNoTracking().ToListAsync();
            
        }
    }
}
