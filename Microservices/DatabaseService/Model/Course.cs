namespace DatabaseService.Model;

public class Course
{
    public int ID { get; set; }
    public string Topic { get; set; }
    public string Address { get; set; }
    public DateTime Date { get; set; }
    public ICollection<Employee> Participants { get; set; } = new List<Employee>();
}
