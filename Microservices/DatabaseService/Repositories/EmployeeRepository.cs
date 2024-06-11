using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly HrDBContext _context;

        public EmployeeRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<Employee?> Add(Employee entity)
        {
			var result = await _context.AddAsync(entity);

			var createdEntity = result.Entity;

			return createdEntity;
		}

        public async Task DeleteAsync(int id)
        {
            Employee? entity = await GetByIdAsync(id);
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
			return await _context.Employees.FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Employee entity)
        {
            _context.Update(entity);
        }
    }
}
