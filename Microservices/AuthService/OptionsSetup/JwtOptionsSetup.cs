using AuthService.Authentication;
using Microsoft.Extensions.Options;

namespace AuthService.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
	private const string SectionName = "Jwt";
	private readonly IConfiguration _config;

	public JwtOptionsSetup(IConfiguration config)
	{
		_config = config;
	}

	public void Configure(JwtOptions options)
	{
		_config.GetSection(SectionName).Bind(options);
	}
}
