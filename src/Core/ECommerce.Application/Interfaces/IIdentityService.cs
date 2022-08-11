using ECommerce.Application.Models;
using ECommerce.Application.Models.IdentityModel;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Interfaces
{
    public interface IIdentityService 
    {
        Task<(Result, string Token)> LoginAsync(LoginModel model);
        Task<Result> RegisterAsync(RegisterModel model, string role =UserRoles.Member);
        Task<Result> RegisterForAdminAsync(RegisterModel model, string role = UserRoles.Admin);
    }
}
