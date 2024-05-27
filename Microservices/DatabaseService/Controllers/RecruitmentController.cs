using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers
{
    public class RecruitmentController : Controller
    {
        private readonly RecruitmentCRUDService _recruitmentCRUDService;

        public RecruitmentController(RecruitmentCRUDService recruitmentCRUDService)
        {
            _recruitmentCRUDService = recruitmentCRUDService;
        }
        [HttpGet]
        public IQueryable GetAll()
        {
            return _recruitmentCRUDService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Recruitment?> GetById(int id)
        {
            return await _recruitmentCRUDService.GetById(id);
        }
        [HttpPost]
        public void Add(Recruitment entity)
        {
            _recruitmentCRUDService.Add(entity);
        }
        [HttpPut("{id}")]
        public void Update(Recruitment entity)
        {
            _recruitmentCRUDService.Update(entity);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _recruitmentCRUDService.Delete(id);
        }
    }
}
