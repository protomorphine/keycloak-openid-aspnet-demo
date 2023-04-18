using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    [Authorize]
    [HttpPost("sing-in")]
    public async Task SingInAsync(CancellationToken ct)
    {
        if (User.Identity?.IsAuthenticated is false)
            await HttpContext.ChallengeAsync();
    }

    [Authorize]
    [HttpGet("sing-out")]
    public async Task SingOutAsync(CancellationToken ct)
    {
        await HttpContext.SignOutAsync();
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
    }
}