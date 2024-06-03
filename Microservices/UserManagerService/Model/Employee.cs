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
}
