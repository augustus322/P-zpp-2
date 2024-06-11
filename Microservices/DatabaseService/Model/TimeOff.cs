namespace DatabaseService.Model;

public enum TimeOffStatus
{
    Pending,
    Approved,
    Denied
}
public class TimeOff
{
    public int ID { get; set; }
    public Employee Employee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeOffStatus Status { get; set; }
}
