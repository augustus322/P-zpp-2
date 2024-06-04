using AuthService.Authentication;
using AuthService.Connectors;
using AuthService.Models;

namespace AuthService.Services;

public class AuthenticationService
{
	private readonly IDatabaseConnector _connector;
	private readonly IJwtProvider _provider;

	public AuthenticationService(IDatabaseConnector connector,
		IJwtProvider provider)
	{
		_connector = connector;
		_provider = provider;
	}

	public async Task<AuthenticationResult> AuthenticateAsync(string email, string passwordHash)
	{
		var result = await _connector.GetUserAsync(email);

		if (!result.IsSuccess)
		{
			return new AuthenticationResult()
			{
				IsSuccess = false,
				Error = result.Error?.Message,
			};
		}

		var user = result.Result!;

		if (user.PasswordHash != passwordHash)
		{
			return new AuthenticationResult()
			{
				IsSuccess = false,
				Error = "Wrong passwordHash",
			};
		}

		return new AuthenticationResult()
		{
			IsSuccess = true,
			Error = null,
		};
	}

	public string GenerateJSONWebToken(UserInfo userInfo)
	{
		return _provider.Generate(userInfo);
	}
}
