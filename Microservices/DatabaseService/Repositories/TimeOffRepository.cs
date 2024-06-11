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

        public async Task<TimeOff?> Add(TimeOff entity)
        {
			var result = await _context.AddAsync(entity);

			var createdEntity = result.Entity;

			return createdEntity;
		}

        public async Task DeleteAsync(int id)
        {
            TimeOff? entity = await GetByIdAsync(id);
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
            _context.Update(entity);
        }
    }
}
