using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers
{
    public class SalaryController : Controller
    {
        private readonly SalaryCRUDService _salaryCRUDService;

        public SalaryController(SalaryCRUDService salaryCRUDService)
        {
            _salaryCRUDService = salaryCRUDService;
        }
        [HttpGet]
        public IQueryable GetAll()
        {
            return _salaryCRUDService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Salary?> GetById(int id)
        {
            return await _salaryCRUDService.GetById(id);
        }
        [HttpPost]
        public void Add(Salary entity)
        {
            _salaryCRUDService.Add(entity);
        }
        [HttpPut("{id}")]
        public void Update(Salary entity)
        {
            _salaryCRUDService.Update(entity);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _salaryCRUDService.Delete(id);
        }
    }
}
