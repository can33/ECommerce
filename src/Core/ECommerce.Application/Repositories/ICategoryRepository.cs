using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repository
{
    public interface ICategoryRepository : IGenericRepositoryAsync<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoryWithProducts();
    }
}
