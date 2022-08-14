using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
