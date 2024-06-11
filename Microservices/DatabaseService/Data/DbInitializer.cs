using DatabaseService.Model;

namespace DatabaseService.Data
{
    public class DbInitializer
    {
        public static void Initialize(HrDBContext context)
        {
            context.Database.EnsureCreated();

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
