using Microsoft.Extensions.Options;
using UserManagerService.Dtos;
using UserManagerService.Model;
using UserManagerService.Options;

namespace UserManagerService.Connectors;

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
	public async Task<ResultObject<IEnumerable<UserReadDto>>> GetUsersAsync()
	{
		var users = await _client.GetFromJsonAsync<List<UserReadDto>>("/api/employees");

		if (users is null)
		{
			return ResultObject<IEnumerable<UserReadDto>>.Failure(new Exception("No users found"));
		}

		return ResultObject<IEnumerable<UserReadDto>>.Success(users);
	}

	public async Task<ResultObject<UserReadDto>> GetUserAsync(int userId)
	{
		var user = await _client.GetFromJsonAsync<UserReadDto>($"/api/employees/{userId}");

		if (user is null)
		{
			return ResultObject<UserReadDto>.Failure(new Exception("No user found"));
		}

		return ResultObject<UserReadDto>.Success(user);
	}

	public async Task<ResultObject<UserReadDto>> CreateUserAsync(UserCreateDto user)
	{
		var response = await _client.PostAsJsonAsync<UserCreateDto>($"/api/employees", user);

		if (response is null)
		{
			return ResultObject<UserReadDto>.Failure(new Exception("No response received"));
		}

		if (!response.IsSuccessStatusCode)
		{
			return ResultObject<UserReadDto>.Failure(new Exception("Not successful response"));
		}

		UserReadDto? createdUser = await response.Content.ReadFromJsonAsync<UserReadDto>();

		return ResultObject<UserReadDto>.Success(createdUser!);
	}

	public async Task<ResultObject<UserReadDto>> UpdateUserAsync(UserCreateDto user, int userId)
	{
		var response = await _client.PutAsJsonAsync<UserCreateDto>($"/api/employees/{userId}", user);

		if (response is null)
		{
			return ResultObject<UserReadDto>.Failure(new Exception("No response received"));
		}

		if (!response.IsSuccessStatusCode)
		{
			return ResultObject<UserReadDto>.Failure(new Exception("Not successful response"));
		}

		UserReadDto? updatedUser = await response.Content.ReadFromJsonAsync<UserReadDto>();

		return ResultObject<UserReadDto>.Success(updatedUser!);
	}

	public async Task<ResultObject<UserReadDto>> DeleteUserAsync(int userId)
	{
		var deletedUser = await _client.DeleteFromJsonAsync<UserReadDto>($"/api/employees/{userId}");

		if (deletedUser is null)
		{
			return ResultObject<UserReadDto>.Failure(new Exception("User was not deleted"));
		}

		return ResultObject<UserReadDto>.Success(deletedUser);
	}
}
