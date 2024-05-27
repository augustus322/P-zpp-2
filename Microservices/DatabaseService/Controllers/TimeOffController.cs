using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers
{
    [ApiController]
    public class TimeOffController : ControllerBase
    {
        private readonly TimeOffCRUDService _timeOffCRUDService;

        public TimeOffController(TimeOffCRUDService timeOffCRUDService)
        {
            _timeOffCRUDService = timeOffCRUDService;
        }
        [HttpGet]
        public IQueryable GetAll()
        {
            return _timeOffCRUDService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<TimeOff?> GetById(int id)
        {
            return await _timeOffCRUDService.GetById(id);
        }
        [HttpPost]
        public void Add(TimeOff entity)
        {
            _timeOffCRUDService.Add(entity);
        }
        [HttpPut("{id}")]
        public void Update(TimeOff entity)
        {
            _timeOffCRUDService.Update(entity);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _timeOffCRUDService.Delete(id);
        }
    }
}
