using DatabaseService.Model;

namespace DatabaseService.Data
{
    public class DbInitializer
    {
        public static void Initialize(HrDBContext context)
        {
            context.Database.EnsureCreated();
            AddCandidates()
            AddEmployees()
            AddSalaries()


            //course
            //meeting
            //recruitment
            //timeoff

            context.SaveChanges();
        }

        private static void AddCandidates()
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
                context.Candidate.Add(item);
            }
        }

        private static void AddEmployees()
        {
            if (context.Employee.Any())
            {
                return;
            }
            foreach (var item in candidates)
            {
                context.Candidates.Add(item);
            }

            var employees = new Employee[]
            {
                new Employee
                {
                    FirstName = 'Karolina',
                    LastName = 'Mąka',
                    Phone = '123123123',
                    Mail = 'karolina@test.com'
                    Address = 'Sezamkowa 21',
                    Position = EmployeePosition.Szef,
                }
                new Employee
                {
                    FirstName = 'Wiktoria',
                    LastName = 'Mrózek',
                    Phone = '234234234',
                    Mail = 'wiktoria@test.com'
                    Address = 'Sezamkowa 37',
                    Position = EmployeePosition.Programista15k,
                }
                new Employee
                {
                    FirstName = 'Dawid',
                    LastName = 'Machaj',
                    Phone = '345345345',
                    Mail = 'dawic@test.com'
                    Address = 'Sezamkowa 420',
                    Position = EmployeePosition.Programista15k,
                }
                new Employee
                {
                    FirstName = 'Mieszko',
                    LastName = 'Niezgoda',
                    Phone = '645456456',
                    Mail = 'mieszko@test.com'
                    Address = 'Sezamkowa 1',
                    Position = EmployeePosition.Programista15k,
                }
            }
            foreach (var item in employees)
            {
                context.Employee.Add(item);
            }
        }

        private static void AddSalaries()
        {
            if (context.Salary.Any())
            {
                return;
            }

            var employees = context.Employee.all
            foreach (var _item in employees)
            {

                salary = new Salary
                {
                    Amount = 150000.00,
                    Employee = context.Employee.take
                    PaymentDate = '2024-06-12T12:30:00Z'
                }
                context.Salary.Add(salary);
            }
        }
    }
}
