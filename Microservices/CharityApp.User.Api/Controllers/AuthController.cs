using CharityApp.DTOS.Auth;
using CharityApp.ResponseModels;
using CharityApp.User.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityApp.User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<RequestResponse<string>>> LoginAsync(LoginDto request)
        {
            return await _authService.LoginAsync(request);
        }
    }
}
