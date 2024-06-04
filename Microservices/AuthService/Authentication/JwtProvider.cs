using AuthService.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Authentication;

public class JwtProvider : IJwtProvider
{
	private readonly JwtOptions _options;

	public JwtProvider(IOptions<JwtOptions> options)
	{
		_options = options.Value;
	}

	public string Generate(UserInfo userInfo)
	{
		string issuer = _options.Issuer; //_config["Jwt:Issuer"]!;
		string audience = _options.Audience; //_config["Jwt:Audience"]!;
		string secretKey = _options.SecretKey; //_config["Jwt:Key"];

		var claims = new Claim[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),
			new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
			new Claim("Role", userInfo.Role),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};

		DateTime expireDate = DateTime.UtcNow.AddHours(1);

		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
		var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(issuer, audience, claims, null, expireDate, signingCredentials);

		string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

		return tokenValue;
	}
}
