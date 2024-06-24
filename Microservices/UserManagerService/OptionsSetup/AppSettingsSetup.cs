using Microsoft.Extensions.Options;
using UserManagerService.Options;

namespace UserManagerService.OptionsSetup;

public class AppSettingsSetup : IConfigureOptions<AppSettings>
{
	private const string SectionName = "AppSettings";
	private readonly IConfiguration _config;

	public AppSettingsSetup(IConfiguration config)
	{
		_config = config;
	}

	public void Configure(AppSettings options)
	{
		_config.GetSection(SectionName).Bind(options);
	}
}
