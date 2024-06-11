using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class CandidateRepository : IRepository<Candidate>
    {
        private readonly HrDBContext _context;

        public CandidateRepository(HrDBContext context)
        {
            _context = context;
        }

        public async Task<Candidate?> Add(Candidate entity)
        {
            var result = await _context.AddAsync(entity);

			var createdEntity = result.Entity;

			return createdEntity;
        }

        public async Task DeleteAsync(int id)
        {
            Candidate? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Candidates.Remove(entity);
            }
        }

        public IQueryable<Candidate> GetAll()
        {
            return _context.Candidates.AsQueryable();
        }

        public async Task<Candidate?> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Candidate entity)
        {
			_context.Candidates.Update(entity);
		}
    }
}
