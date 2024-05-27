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
        public void Add(Course entity)
        {
            _repository.Add(entity);
            _repository.SaveAsync();
        }
        public void Update(Course entity)
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
