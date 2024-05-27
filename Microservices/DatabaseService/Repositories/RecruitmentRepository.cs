using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class RecruitmentRepository : IRepository<Recruitment>
    {
        private readonly HrDBContext _context;

        public RecruitmentRepository(HrDBContext context)
        {
            _context = context;
        }

        public void Add(Recruitment entity)
        {
            _context.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Recruitment entity = _context.Recruitments.Find(id);
            if (entity != null)
            {
                _context.Recruitments.Remove(entity);
            }
        }

        public IQueryable<Recruitment> GetAll()
        {
            return _context.Recruitments.AsQueryable();
        }

        public async Task<Recruitment?> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Recruitment entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
