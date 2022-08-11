using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Models.IdentityModel;

namespace ECommerce.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountsController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterForMember([FromBody] RegisterModel model)
        {
            var result = await _identityService.RegisterAsync(model);
            if (result.Succeeded)
                return Created("~/api/accounts", model);
            else if (!result.Succeeded)
                return BadRequest(result.Errors);
            else
                return StatusCode(501);
        }
        [HttpPost("Register-Admin")]
        public async Task<IActionResult> RegisterForAdmin([FromBody] RegisterModel model)
        {
            var result = await _identityService.RegisterForAdminAsync(model);

            if (result.Succeeded)
                return Created("~/api/accounts", model);

            else if (!result.Succeeded)
                return BadRequest(result.Errors);

            else
                return StatusCode(501);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _identityService.LoginAsync(model);

            if (result.Item1.Succeeded)
            {
                Response.Headers.Add("JWT", result.Token);
                
                return Ok();
            }
            
            return BadRequest(result.Item1.Errors);
        }
    }
}
