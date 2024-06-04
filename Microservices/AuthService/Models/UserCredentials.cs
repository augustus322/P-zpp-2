// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthService.Models;

public class UserCredentials
{
	public string Email { get; set; }
	public string PasswordHash { get; set; }
}