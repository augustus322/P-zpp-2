using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
	public class SalaryRepository : IRepository<Salary>
	{
		private readonly HrDBContext _context;

		public SalaryRepository(HrDBContext context)
		{
			_context = context;
		}

		public async Task<Salary?> Add(Salary entity)
		{
			var result = await _context.AddAsync(entity);

			var createdEntity = result.Entity;

			return createdEntity;
		}

		public async Task DeleteAsync(int id)
		{
			Salary? entity = await GetByIdAsync(id);
			if (entity != null)
			{
				_context.Salaries.Remove(entity);
			}
		}

		public IQueryable<Salary> GetAll()
		{
			return _context.Salaries
				.Include(s => s.Employee)
				.AsQueryable();
		}

		public async Task<Salary?> GetByIdAsync(int id)
		{
			return await GetAll()
				.Include(s => s.Employee)
				.FirstOrDefaultAsync(x => x.ID == id);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Update(Salary entity)
		{
			_context.Update(entity);
		}
	}
}
