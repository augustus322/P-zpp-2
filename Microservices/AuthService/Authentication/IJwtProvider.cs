using AuthService.Models;

namespace AuthService.Authentication;

public interface IJwtProvider
{
	string Generate(UserInfo userInfo);
}
