using ECommerce.Application.Interfaces.Repository;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Repositories
{
    public interface ICustomerRepository : IGenericRepositoryAsync<Customer>
    {
    }
}
