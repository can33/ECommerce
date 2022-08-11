using ECommerce.Application.Interfaces.Repository;
using ECommerce.Domain.Entities;
using System.Collections;

namespace ECommerce.Application.Repositories
{
    public interface IBrandRepository : IGenericRepositoryAsync<Brand>
    {
        Task<IEnumerable> GetAllBrandWithProducts();
    }
}
