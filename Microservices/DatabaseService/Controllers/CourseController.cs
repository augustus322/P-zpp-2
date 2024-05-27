using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseCRUDService _courseCRUDService;

        public CourseController(CourseCRUDService courseCRUDService)
        {
            _courseCRUDService = courseCRUDService;
        }
        [HttpGet]
        public IQueryable GetAll()
        {
            return _courseCRUDService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Course?> GetById(int id)
        {
            return await _courseCRUDService.GetById(id);
        }
        [HttpPost]
        public void Add(Course entity)
        {
            _courseCRUDService.Add(entity);
        }
        [HttpPut("{id}")]
        public void Update(Course entity)
        {
            _courseCRUDService.Update(entity);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _courseCRUDService.Delete(id);
        }
    }
}
