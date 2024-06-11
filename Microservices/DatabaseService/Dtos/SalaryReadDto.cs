using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class SalaryReadDto
{
	public int ID { get; set; }
	public Employee Employee { get; set; }
	public double Ammount { get; set; }
	public DateTime PaymentDate { get; set; }
}
