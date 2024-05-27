using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class MeetingRepository : IRepository<Meeting>
    {
        private readonly HrDBContext _context;

        public MeetingRepository(HrDBContext context)
        {
            _context = context;
        }

        public void Add(Meeting entity)
        {
            _context.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Meeting entity = _context.Meetings.Find(id);
            if (entity != null)
            {
                _context.Meetings.Remove(entity);
            }
        }

        public IQueryable<Meeting> GetAll()
        {
            return _context.Meetings.AsQueryable();
        }

        public async Task<Meeting?> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Meeting entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
