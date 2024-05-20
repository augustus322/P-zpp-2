using DatabaseService.Model;

namespace DatabaseService.Data
{
    public class DbInitializer
    {
        public static void Initialize(HrDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var candidates = new Candidate[]
            {
                new Candidate
                {
                    FirstName = "",
                    LastName = "",
                    Phone = "",
                    Mail = "",
                    Address = ""
                }
            };
            foreach (var item in candidates)
            {
                context.Candidates.Add(item);
            }

            //course
            //employee
            //meeting
            //recruitment
            //salary
            //timeoff

            context.SaveChanges();
        }
    }
}
