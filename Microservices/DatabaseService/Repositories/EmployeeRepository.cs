using DatabaseService.Data;
using DatabaseService.Model;

namespace DatabaseService.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly HrDBContext _context;

        public EmployeeRepository(HrDBContext context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {
            _context.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Employee entity = _context.Employees.Find(id);
            if (entity != null)
            {
                _context.Employees.Remove(entity);
            }
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Employees.AsQueryable();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
