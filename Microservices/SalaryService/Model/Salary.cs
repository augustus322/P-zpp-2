namespace DatabaseService.Model;

public class Salary
{
    public int ID { get; set; }
    public Employee Employee { get; set; }
    public double Ammount { get; set; }
    public DateTime PaymentDate { get; set; }
}
