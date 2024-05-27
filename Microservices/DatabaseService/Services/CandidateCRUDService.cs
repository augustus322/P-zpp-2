using DatabaseService.Model;

namespace DatabaseService.Services
{
    public class CandidateCRUDService
    {
        private readonly IRepository<Candidate> _repository;

        public CandidateCRUDService(IRepository<Candidate> repository)
        {
            _repository = repository;
        }

        public IQueryable<Candidate> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<Candidate?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public void Add(Candidate entity)
        {
            _repository.Add(entity);
            _repository.SaveAsync();
        }
        public void Update(Candidate entity)
        {
            _repository.Update(entity);
            _repository.SaveAsync();
        }
        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

    }
}
