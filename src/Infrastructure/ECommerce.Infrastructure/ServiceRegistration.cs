using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Application.Interfaces;
using ECommerce.Infrastructure.Identity;

namespace ECommerce.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IIdentityService, IdentityService>();

        }
    }
}
