using DatabaseService.Model;

namespace DatabaseService.Services
{
    public class MeetingCRUDService
    {
        private readonly IRepository<Meeting> _repository;

        public MeetingCRUDService(IRepository<Meeting> candidateRepository)
        {
            _repository = candidateRepository;
        }

        public IQueryable<Meeting> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<Meeting?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Meeting?> AddAsync(Meeting entity)
        {
			var createdEntity = await _repository.Add(entity);
			await _repository.SaveAsync();

			return createdEntity;
		}
        public async Task Update(Meeting entity)
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
