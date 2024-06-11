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
        public async Task<Salary?> AddAsync(Salary entity)
        {
			var createdEntity = await _repository.Add(entity);
			await _repository.SaveAsync();

			return createdEntity;
		}
        public async Task Update(Salary entity)
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
