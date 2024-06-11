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
        public async Task<TimeOff?> AddAsync(TimeOff entity)
        {
			var createdEntity = await _repository.Add(entity);
			await _repository.SaveAsync();

			return createdEntity;
		}
        public async Task Update(TimeOff entity)
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
