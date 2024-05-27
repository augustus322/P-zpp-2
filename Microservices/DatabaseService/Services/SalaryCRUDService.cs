using DatabaseService.Model;

namespace DatabaseService.Services
{
    public class SalaryCRUDService
    {
        private readonly IRepository<Salary> _repository;

        public SalaryCRUDService(IRepository<Salary> candidateRepository)
        {
            _repository = candidateRepository;
        }

        public IQueryable<Salary> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<Salary?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public void Add(Salary entity)
        {
            _repository.Add(entity);
            _repository.SaveAsync();
        }
        public void Update(Salary entity)
        {
            _repository.Update(entity);
            _repository.SaveAsync();
        }
        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
            _repository.SaveAsync();
        }

    }
}
