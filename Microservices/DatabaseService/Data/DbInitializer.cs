using DatabaseService.Model;

namespace DatabaseService.Data;

public class DbInitializer
{
	public static void Initialize(HrDBContext context)
	{
		context.Database.EnsureCreated();

		AddCandidates(context);
		AddEmployees(context);
		AddSalaries(context);

		//course
		//meeting
		//recruitment
		//timeoff
	}

	private static void AddCandidates(HrDBContext context)
	{
		if (context.Candidates.Any())
		{
			return;
		}

		var candidates = new Candidate[]
		{
			new Candidate
			{
				FirstName = "test",
				LastName = "candidate",
				Phone = "123456789",
				Email = "test@com",
				Address = "address"
			}
		};

		foreach (var item in candidates)
		{
			context.Candidates.Add(item);
		}

		context.SaveChanges();
	}

	private static void AddEmployees(HrDBContext context)
	{
		if (context.Employees.Any())
		{
			return;
		}

		var employees = new Employee[]
		{
			new Employee
			{
				FirstName = "Karolina",
				LastName = "Mąka",
				Phone = "123123123",
				Email = "karolina@test.com",
				Address = "Sezamkowa 21",
				Position = EmployeePosition.Szef,
			},
			new Employee
			{
				FirstName = "Wiktoria",
				LastName = "Mrózek",
				Phone = "234234234",
				Email= "wiktoria@test.com",
				Address = "Sezamkowa 37",
				Position = EmployeePosition.Programista15k,
			},
			new Employee
			{
				FirstName = "Dawid",
				LastName = "Machaj",
				Phone = "345345345",
				Email = "dawic@test.com",
				Address = "Sezamkowa 420",
				Position = EmployeePosition.Programista15k,
			},
			new Employee
			{
				FirstName = "Mieszko",
				LastName = "Niezgoda",
				Phone = "645456456",
				Email = "mieszko@test.com",
				Address = "Sezamkowa 1",
				Position = EmployeePosition.Programista15k,
			}
		};

		foreach (var item in employees)
		{
			context.Employees.Add(item);
		}

		context.SaveChanges();
	}

	private static void AddSalaries(HrDBContext context)
	{
		if (context.Salaries.Any())
		{
			return;
		}

		var employees = context.Employees.ToList();

		foreach (var _item in employees)
		{

			var salary = new Salary
			{
				Amount = 150000.00,
				Employee = _item,
				EmployeeID = _item.ID,
				PaymentDate = DateTime.Parse("2024-06-12T12:30:00Z"),
			};

			context.Salaries.Add(salary);
		}

		context.SaveChanges();
	}
}
