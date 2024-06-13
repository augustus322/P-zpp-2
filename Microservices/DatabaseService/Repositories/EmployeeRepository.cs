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
			return _context.Employees
				.Include(e => e.Recruitments)
					.ThenInclude(r => r.Candidate)
				.Include(e => e.TimeOffs)
				.Include(e => e.Salaries)
				.Include(e => e.Courses)
				.Include(e => e.Meetings)
				.AsQueryable();
		}

		public async Task<Employee?> GetByIdAsync(int id)
		{
			return await _context.Employees
				.Include(e => e.Recruitments)
					.ThenInclude(r => r.Candidate)
				.Include(e => e.TimeOffs)
				.Include(e => e.Salaries)
				.Include(e => e.Courses)
				.Include(e => e.Meetings)
				.FirstOrDefaultAsync(e => e.ID == id);
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
