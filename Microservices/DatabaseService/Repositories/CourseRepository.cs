using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly HrDBContext _context;

        public CourseRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<Course?> Add(Course entity)
        {
			var result = await _context.AddAsync(entity);

			var createdEntity = result.Entity;

			return createdEntity;
		}

        public async Task DeleteAsync(int id)
        {
            Course? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Courses.Remove(entity);
            }
        }

        public IQueryable<Course> GetAll()
        {
            return _context.Courses.AsQueryable();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Course entity)
        {
            _context.Update(entity);
        }
    }
}
