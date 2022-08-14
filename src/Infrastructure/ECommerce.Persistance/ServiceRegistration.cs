using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Repositories;
using ECommerce.Infrastructure.Identity;
using ECommerce.Persistance.Contexts;
using ECommerce.Persistance.Repositories;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));

            //serviceCollection.AddDbContext<ApplicationPostgreSqlDbContext>(options => options.UseNpgsql(configuration["PostgreSql:PostgreSqlConnection"]));

            serviceCollection.AddIdentity<AppUser, AppRole>(options =>
            {

                options.Password.RequiredLength = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            serviceCollection.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<IBrandRepository, BrandRepository>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();

            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidAudience = configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                    NameClaimType = ClaimTypes.Name,

                };
            });


        }


    }
}
