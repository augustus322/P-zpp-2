using AuthService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly Services.AuthenticationService _authService;

	public AuthController(Services.AuthenticationService authService)
	{
		_authService = authService;
	}

	[AllowAnonymous]
	[HttpPost]
	public async Task<IActionResult> Login([FromBody] UserCredentials userCredentials)
	{
		var email = userCredentials.Email;
		var pass = userCredentials.PasswordHash;

		var authResult = await _authService.AuthenticateAsync(email, pass);

		if (!authResult.IsSuccess)
		{
			return Unauthorized();
		}

		var userToken = _authService.GenerateJSONWebToken(authResult.User!);

		return Ok(new { token = userToken });
	}
}
