using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class SalaryCreateDto
{
	public int EmployeeID { get; set; }
	public double Amount { get; set; }
	public DateTime PaymentDate { get; set; }
}
