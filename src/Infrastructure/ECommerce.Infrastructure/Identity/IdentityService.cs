using ECommerce.Application.Interfaces;
using ECommerce.Application.Models;
using ECommerce.Application.Models.IdentityModel;
using ECommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Infrastructure.Identity
{
    internal class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<Result> RegisterAsync(RegisterModel model, string role = UserRoles.Member)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists is null)
            {
                AppUser appUser = new()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = $"{model.FirstName}{model.LastName}"
                };
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    await CreateRole(role);
                    await _userManager.AddToRoleAsync(appUser, role.ToString());
                    return Result.Success();
                }
                else
                {
                    string errors = System.Text.Json.JsonSerializer.Serialize(result.Errors);
                    return Result.Failed(new string[] { errors });
                }
            }
            else return Result.Failed(new string[] { "An account registered with this email already exists" });
        }
        public async Task<Result> RegisterForAdminAsync(RegisterModel model, string role = UserRoles.Admin)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists is null)
            {
                AppUser appUser = new()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = $"{model.FirstName}{model.LastName}"
                };
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    await CreateRole(role);
                    await _userManager.AddToRoleAsync(appUser, role.ToString());
                    return Result.Success();
                }
                else
                {
                    string errors = System.Text.Json.JsonSerializer.Serialize(result.Errors);
                    return Result.Failed(new string[] { errors });
                }
            }
            else return Result.Failed(new string[] { "An account registered with this email already exists" });
        }
        public async Task CreateRole(string role)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new AppRole { Name = role });

            }

        }
        
        private string GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            
            var token = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var tokenHandler  = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.WriteToken(token);
            
            return jwt;

        }

        public async Task<(Result, string Token)> LoginAsync(LoginModel model)
        {
            var appUser = await _userManager.FindByEmailAsync(model.Email);
            if (appUser is not null && await _userManager.CheckPasswordAsync(appUser, model.Password))
            {
                var appUserRoles = await _userManager.GetRolesAsync(appUser);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,appUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var role in appUserRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                var token = GetToken(authClaims);

                return (Result.Success(), token.ToString());
            }
            else return (Result.Failed(new string[] { "Email or password invalid." }), "");
        }
    }
}
