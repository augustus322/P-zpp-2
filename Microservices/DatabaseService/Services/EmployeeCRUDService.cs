using DatabaseService.Model;

namespace DatabaseService.Services
{
    public class EmployeeCRUDService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeCRUDService(IRepository<Employee> candidateRepository)
        {
            _repository = candidateRepository;
        }

        public IQueryable<Employee> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<Employee?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Employee?> AddAsync(Employee entity)
        {
			var createdEntity = await _repository.Add(entity);
			await _repository.SaveAsync();

			return createdEntity;
		}
        public async Task Update(Employee entity)
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
