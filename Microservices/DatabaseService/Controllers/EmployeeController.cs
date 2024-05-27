using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeCRUDService _employeeCRUDService;

        public EmployeeController(EmployeeCRUDService employeeCRUDService)
        {
            _employeeCRUDService = employeeCRUDService;
        }
        [HttpGet]
        public IQueryable GetAll()
        {
            return _employeeCRUDService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Employee?> GetById(int id)
        {
            return await _employeeCRUDService.GetById(id);
        }
        [HttpPost]
        public void Add(Employee entity)
        {
            _employeeCRUDService.Add(entity);
        }
        [HttpPut("{id}")]
        public void Update(Employee entity)
        {
            _employeeCRUDService.Update(entity);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeCRUDService.Delete(id);
        }
    }
}
