using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class TimeOffCreateDto
{
	public Employee Employee { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public TimeOffStatus Status { get; set; }
}
