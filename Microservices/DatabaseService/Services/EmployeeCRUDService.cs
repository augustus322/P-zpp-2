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
        public void Add(Employee entity)
        {
            _repository.Add(entity);
            _repository.SaveAsync();
        }
        public void Update(Employee entity)
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
