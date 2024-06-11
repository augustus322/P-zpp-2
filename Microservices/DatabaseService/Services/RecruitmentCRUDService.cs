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
        public async Task<Recruitment?> AddAsync(Recruitment entity)
        {
			var createdEntity = await _repository.Add(entity);
			await _repository.SaveAsync();

			return createdEntity;
		}
        public async Task Update(Recruitment entity)
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
