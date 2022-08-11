using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepositoryAsync<Product>
    {
        Task<IEnumerable<Product>> GetAllProductWithCategoryAndBrand();
    }
}
