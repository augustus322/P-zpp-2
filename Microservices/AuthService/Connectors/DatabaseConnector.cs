using AuthService.Dtos;
using AuthService.Models;
using AuthService.Options;
using Microsoft.Extensions.Options;

namespace AuthService.Connectors;

public class DatabaseConnector : IDatabaseConnector
{
	private readonly AppSettings _appSettings;

	private HttpClient _client { get; set; }

	public DatabaseConnector(HttpClient client,
		IOptions<AppSettings> appSettings)
	{
		_client = client;
		_appSettings = appSettings.Value;

		var databaseServiceAddress = _appSettings.HostAddresses.DatabaseService;

		_client.BaseAddress = new Uri(databaseServiceAddress);
	}

	public async Task<ResultObject<UserInfo>> GetUserAsync(string email)
	{
		var users = await _client.GetFromJsonAsync<List<EmployeeReadDto>>("/api/employees");

		var user = users?.SingleOrDefault(u => u.Email == email);

		if (user is null)
		{
			return new ResultObject<UserInfo>()
			{
				Result = null,
				Error = new Exception("No user found"),
				IsSuccess = false,
			};
		}

		var userInfo = new UserInfo
		{
			Id = user.ID,
			Email = user.Email,
			Name = $"{user.FirstName} {user.LastName}",
			PasswordHash = "pass", // tmp pass hash
			Role = "test", // tmp role
		};

		return new ResultObject<UserInfo>()
		{
			Result = userInfo,
			Error = null,
			IsSuccess = true,
		};
	}
}
