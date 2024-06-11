using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidatesController : ControllerBase
{
	private readonly CandidateCRUDService _candidateCRUDService;
	private readonly IMapper _mapper;

	public CandidatesController(CandidateCRUDService candidateCRUDService,
		IMapper mapper)
	{
		_candidateCRUDService = candidateCRUDService;
		_mapper = mapper;
	}

	[HttpGet]
	public ActionResult<IEnumerable<CandidateReadDto>> GetAllCandidates()
	{
		IOrderedEnumerable<Candidate> candidates;

		try
		{
			candidates = _candidateCRUDService.GetAll()
				.ToList().OrderBy(c => c.ID);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{nameof(candidates)} could not be fetched from DB, error msg: {ex.Message}");
			throw;
		}

		return Ok(_mapper.Map<IEnumerable<CandidateReadDto>>(candidates));
	}

	[HttpGet("{id}", Name = "GetCandidateById")]
	public async Task<ActionResult<CandidateReadDto>> GetCandidateById(int id)
	{
		var candidate = await _candidateCRUDService.GetById(id);

		if (candidate is null)
		{
			return NotFound();
		}

		return Ok(_mapper.Map<CandidateReadDto>(candidate));
	}

	[HttpPost]
	public async Task<ActionResult<CandidateReadDto>> CreateCandidate([FromBody] CandidateCreateDto createDto)
	{
		if (createDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createDto)));
		}

		var candidateToCreate = _mapper.Map<Candidate>(createDto);

		var createdCandidate = await _candidateCRUDService.AddAsync(candidateToCreate);

		var candidateReadDto = _mapper.Map<CandidateReadDto>(createdCandidate);

		return CreatedAtRoute(nameof(GetCandidateById), new { id = candidateReadDto.ID }, candidateReadDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<CandidateReadDto>> UpdateCandidate(int id, CandidateCreateDto updateCandidateDto)
	{
		var candidateToUpdate = await _candidateCRUDService.GetById(id);

		if (candidateToUpdate is null)
		{
			return NotFound();
		}

		candidateToUpdate.FirstName = updateCandidateDto.FirstName;
		candidateToUpdate.LastName = updateCandidateDto.LastName;
		candidateToUpdate.Phone = updateCandidateDto.Phone;
		candidateToUpdate.Email = updateCandidateDto.Email;
		candidateToUpdate.Address = updateCandidateDto.Address;

		try
		{
			await _candidateCRUDService.Update(candidateToUpdate);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");

			throw;
		}

		return Ok(_mapper.Map<CandidateReadDto>(candidateToUpdate));
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<CandidateReadDto>> DeleteCandidate(int id)
	{
		var candidateToDelete = await _candidateCRUDService.GetById(id);

		if (candidateToDelete is null)
		{
			return NotFound();
		}

		await _candidateCRUDService.Delete(id);

		return Ok(_mapper.Map<CandidateReadDto>(candidateToDelete));
	}
}
