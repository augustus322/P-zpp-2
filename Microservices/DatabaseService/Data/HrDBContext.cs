using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Data;

public class HrDBContext : DbContext
{
    public HrDBContext(DbContextOptions<HrDBContext> options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Recruitment> Recruitments { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<TimeOff> TimeOffs { get; set; }
}
