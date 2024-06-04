namespace AuthService.Models;

public class AuthenticationResult
{
	public bool IsSuccess { get; set; }
	public string? Error { get; set; }
	public UserInfo? User { get; set; }
}