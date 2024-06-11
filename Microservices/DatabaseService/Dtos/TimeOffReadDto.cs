using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class TimeOffReadDto
{
	public int ID { get; set; }
	public Employee Employee { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public TimeOffStatus Status { get; set; }
}
