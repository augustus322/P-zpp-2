namespace UserManagerService.Model;

public class ResultObject<T>
	where T : class
{
	public T? Result { get; set; }
	public Exception? Error { get; set; }
	public bool IsSuccess { get; set; }

	private ResultObject(T? result, Exception? error, bool isSuccess)
	{
		Result = result;
		Error = error;
		IsSuccess = isSuccess;
	}
	
	public static ResultObject<T> Success(T? result)
	{
		return new ResultObject<T>(result, null,true);
	}

	public static ResultObject<T> Failure(Exception error)
	{
		return new ResultObject<T>(null, error, false);
	}
}