using DatabaseService.Data;
using DatabaseService.Model;

namespace DatabaseService.Repositories
{
    public class CandidateRepository : IRepository<Candidate>
    {
        private readonly HrDBContext _context;

        public CandidateRepository(HrDBContext context)
        {
            _context = context;
        }

        public void Add(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Candidate> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Candidate?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Candidate entity)
        {
            throw new NotImplementedException();
        }
    }
}
