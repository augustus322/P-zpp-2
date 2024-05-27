using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers
{
    public class MeetingController : Controller
    {
        private readonly MeetingCRUDService _meetingCRUDService;

        public MeetingController(MeetingCRUDService meetingCRUDService)
        {
            _meetingCRUDService = meetingCRUDService;
        }
        [HttpGet]
        public IQueryable GetAll()
        {
            return _meetingCRUDService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Meeting?> GetById(int id)
        {
            return await _meetingCRUDService.GetById(id);
        }
        [HttpPost]
        public void Add(Meeting entity)
        {
            _meetingCRUDService.Add(entity);
        }
        [HttpPut("{id}")]
        public void Update(Meeting entity)
        {
            _meetingCRUDService.Update(entity);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _meetingCRUDService.Delete(id);
        }
    }
}
