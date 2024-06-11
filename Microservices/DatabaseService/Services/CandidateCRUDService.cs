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
        public async Task<Candidate?> AddAsync(Candidate entity)
        {
            var createdEntity = await _repository.Add(entity);
            await _repository.SaveAsync();

			return createdEntity;
        }
        public async Task Update(Candidate entity)
        {
            _repository.Update(entity);
            await _repository.SaveAsync();
        }
        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

    }
}
