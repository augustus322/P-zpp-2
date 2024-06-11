using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class SalaryCreateDto
{
	public Employee Employee { get; set; }
	public double Ammount { get; set; }
	public DateTime PaymentDate { get; set; }
}
