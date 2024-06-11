namespace DatabaseService.Model;

public enum EmployeePosition
{

}
public class Employee
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Address { get; set; }
    public EmployeePosition Position { get; set; }
	public ICollection<TimeOff> TimeOffs { get; set; } = new List<TimeOff>();
    public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
    public ICollection<Recruitment> Recruitments { get; set; } = new List<Recruitment>();
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
