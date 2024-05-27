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

        public void Add(Salary entity)
        {
            _context.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Salary entity = _context.Salaries.Find(id);
            if (entity != null)
            {
                _context.Salaries.Remove(entity);
            }
        }

        public IQueryable<Salary> GetAll()
        {
            return _context.Salaries.AsQueryable();
        }

        public async Task<Salary?> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Salary entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
