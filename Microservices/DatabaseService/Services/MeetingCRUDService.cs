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
        public void Add(Meeting entity)
        {
            _repository.Add(entity);
            _repository.SaveAsync();
        }
        public void Update(Meeting entity)
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
