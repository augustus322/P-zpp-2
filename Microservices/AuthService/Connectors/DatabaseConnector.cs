using AuthService.Models;

namespace AuthService.Connectors;

public class DatabaseConnector : IDatabaseConnector
{
	public HttpClient Client { get; set; }

	public DatabaseConnector(HttpClient client)
	{
		Client = client;
	}

	const string BaseAddress = "databaseService/"; // TODO: change that later

	public async Task<ResultObject<UserInfo>> GetUserAsync(string email)
	{
		var users = await Client.GetFromJsonAsync<List<UserInfo>>($"{BaseAddress}users");

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

		return new ResultObject<UserInfo>()
		{
			Result = user,
			Error = null,
			IsSuccess = true,
		};
	}
}
