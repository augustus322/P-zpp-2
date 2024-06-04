namespace AuthService.Models;

public class ResultObject<T>
	where T : class
{
	public T? Result { get; set; }
	public Exception? Error { get; set; }
	public bool IsSuccess { get; set; }
}