using DatabaseService.Model;

namespace DatabaseService.Services
{
    public class CourseCRUDService
    {
        private readonly IRepository<Course> _repository;

        public CourseCRUDService(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public IQueryable<Course> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<Course?> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Course?> AddAsync(Course entity)
        {
			var createdEntity = await _repository.Add(entity);
			await _repository.SaveAsync();

			return createdEntity;
		}
        public async Task Update(Course entity)
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
