using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class SalaryReadDto
{
	public int ID { get; set; }
	public int EmployeeID { get; set; }
	public double Amount { get; set; }
	public DateTime PaymentDate { get; set; }
}
