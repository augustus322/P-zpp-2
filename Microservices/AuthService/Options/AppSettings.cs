namespace AuthService.Options;

public class AppSettings
{
	public HostAddressesOptions HostAddresses { get; init; }
}

public class HostAddressesOptions
{
	public string DatabaseService { get; init; }
}
