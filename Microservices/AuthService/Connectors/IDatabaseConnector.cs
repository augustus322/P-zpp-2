using AuthService.Models;

namespace AuthService.Connectors;
public interface IDatabaseConnector
{
	Task<ResultObject<UserInfo>> GetUserAsync(string email);
}