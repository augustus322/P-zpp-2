using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers
{
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateCRUDService _candidateCRUDService;

        public CandidateController(CandidateCRUDService candidateCRUDService)
        {
            _candidateCRUDService = candidateCRUDService;
        }
        [HttpGet]
        public IQueryable GetAll()
        {
            return _candidateCRUDService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Candidate?> GetById(int id)
        {
            return await _candidateCRUDService.GetById(id);
        }
        [HttpPost]
        public void Add(Candidate entity)
        {
            _candidateCRUDService.Add(entity);
        }
        [HttpPut("{id}")]
        public void Update(Candidate entity)
        {
            _candidateCRUDService.Update(entity);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _candidateCRUDService.Delete(id);
        }
    }
}
