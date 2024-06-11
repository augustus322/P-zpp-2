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

        public async Task<Meeting?> Add(Meeting entity)
        {
			var result = await _context.AddAsync(entity);

			var createdEntity = result.Entity;

			return createdEntity;
		}

        public async Task DeleteAsync(int id)
        {
            Meeting? entity = await GetByIdAsync(id);
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
			_context.Update(entity);
		}
    }
}
