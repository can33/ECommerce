using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<T> where T : class ,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByFilterAsync(Expression<Func<T,bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
