using Microsoft.Extensions.Options;
using RecruitmentService.Options;

namespace RecruitmentService.OptionsSetup;

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
