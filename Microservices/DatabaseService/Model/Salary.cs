namespace DatabaseService.Model;

public class Salary
{
    public int ID { get; set; }
    public int EmployeeID { get; set; }
    public Employee Employee { get; set; }
    public double Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}