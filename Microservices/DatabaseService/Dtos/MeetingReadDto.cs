namespace DatabaseService.Dtos;

public class MeetingReadDto
{
	public int ID { get; set; }
	public string Topic { get; set; }
	public string Address { get; set; }
	public DateTime Date { get; set; }
}
