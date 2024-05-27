using DatabaseService.Model;

namespace DatabaseService.Services
{
    public class RecruitmentCRUDService
    {
        private readonly IRepository<Recruitment> _repository;

        public RecruitmentCRUDService(IRepository<Recruitment> candidateRepository)
        {
            _repository = candidateRepository;
        }

        public IQueryable<Recruitment> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<Recruitment?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public void Add(Recruitment entity)
        {
            _repository.Add(entity);
            _repository.SaveAsync();
        }
        public void Update(Recruitment entity)
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
