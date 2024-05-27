using DatabaseService.Model;

namespace DatabaseService.Services
{
    public class TimeOffCRUDService
    {
        private readonly IRepository<TimeOff> _repository;

        public TimeOffCRUDService(IRepository<TimeOff> candidateRepository)
        {
            _repository = candidateRepository;
        }

        public IQueryable<TimeOff> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<TimeOff?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public void Add(TimeOff entity)
        {
            _repository.Add(entity);
            _repository.SaveAsync();
        }
        public void Update(TimeOff entity)
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
