using UserManagerService.Dtos;
using UserManagerService.Model;

namespace UserManagerService.Connectors;
public interface IDatabaseConnector
{
	Task<ResultObject<IEnumerable<UserReadDto>>> GetUsersAsync();
	Task<ResultObject<UserReadDto>> GetUserAsync(int userId);
	Task<ResultObject<UserReadDto>> CreateUserAsync(UserCreateDto user);
	Task<ResultObject<UserReadDto>> UpdateUserAsync(UserCreateDto user, int userId);
	Task<ResultObject<UserReadDto>> DeleteUserAsync(int userId);
}