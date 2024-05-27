using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class TimeOffRepository : IRepository<TimeOff>
    {
        private readonly HrDBContext _context;

        public TimeOffRepository(HrDBContext context)
        {
            _context = context;
        }

        public void Add(TimeOff entity)
        {
            _context.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            TimeOff entity = _context.TimeOffs.Find(id);
            if (entity != null)
            {
                _context.TimeOffs.Remove(entity);
            }
        }

        public IQueryable<TimeOff> GetAll()
        {
            return _context.TimeOffs.AsQueryable();
        }

        public async Task<TimeOff?> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TimeOff entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
