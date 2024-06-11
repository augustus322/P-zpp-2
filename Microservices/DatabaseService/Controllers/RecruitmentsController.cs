using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecruitmentsController : ControllerBase
{
	private readonly RecruitmentCRUDService _recruitmentCRUDService;
	private readonly CandidateCRUDService _candidateCRUDService;
	private readonly EmployeeCRUDService _employeeCRUDService;
	private readonly IMapper _mapper;

	public RecruitmentsController(RecruitmentCRUDService recruitmentCRUDService,
		IMapper mapper,
		CandidateCRUDService candidateCRUDService,
		EmployeeCRUDService employeeCRUDService)
	{
		_recruitmentCRUDService = recruitmentCRUDService;
		_mapper = mapper;
		_candidateCRUDService = candidateCRUDService;
		_employeeCRUDService = employeeCRUDService;
	}

	[HttpGet]
	public ActionResult<IEnumerable<RecruitmentReadDto>> GetAllRecruitments()
	{
		IOrderedEnumerable<Recruitment> recruitments;

		try
		{
			recruitments = _recruitmentCRUDService.GetAll()
				.ToList().OrderBy(c => c.ID);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{nameof(recruitments)} could not be fetched from DB, error msg: {ex.Message}");
			throw;
		}

		return Ok(_mapper.Map<IEnumerable<RecruitmentReadDto>>(recruitments));
	}

	[HttpGet("{id}", Name = "GetRecruitmentById")]
	public async Task<ActionResult<RecruitmentReadDto>> GetRecruitmentById(int id)
	{
		var recruitment = await _recruitmentCRUDService.GetById(id);

		if (recruitment is null)
		{
			return NotFound();
		}

		return Ok(_mapper.Map<RecruitmentReadDto>(recruitment));
	}

	[HttpPost]
	public async Task<ActionResult<RecruitmentCreateDto>> CreateRecruitment([FromBody] RecruitmentCreateDto createDto)
	{
		if (createDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createDto)));
		}

		var recruitmentToCreate = _mapper.Map<Recruitment>(createDto);

		var candidate = await _candidateCRUDService
			.GetById(recruitmentToCreate.CandidateID);

		if (candidate is null)
		{
			return NotFound($"No {nameof(candidate)} with Id = {recruitmentToCreate.CandidateID} was found in DB");
		}

		var recruiter = await _employeeCRUDService
			.GetById(recruitmentToCreate.RecruiterID);

		if (recruiter is null)
		{
			return NotFound($"No {nameof(recruiter)} with Id = {recruitmentToCreate.RecruiterID} was found in DB");
		}

		recruitmentToCreate.Candidate = candidate;
		recruitmentToCreate.Recruiter = recruiter;

		var createdRecruitment = await _recruitmentCRUDService.AddAsync(recruitmentToCreate);

		var recruitmentReadDto = _mapper.Map<RecruitmentReadDto>(createdRecruitment);

		return CreatedAtRoute(nameof(GetRecruitmentById), new { id = recruitmentReadDto.ID }, recruitmentReadDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<RecruitmentReadDto>> UpdateRecruitment(int id, RecruitmentCreateDto updateDto)
	{
		var recruitmentToUpdate = await _recruitmentCRUDService.GetById(id);

		if (recruitmentToUpdate is null)
		{
			return NotFound();
		}

		if (recruitmentToUpdate.CandidateID != updateDto.CandidateID)
		{
			var candidate = await _candidateCRUDService
				.GetById(updateDto.CandidateID);

			if (candidate is null)
			{
				return NotFound($"No {nameof(candidate)} with Id = {updateDto.CandidateID} was found in DB");
			}

			recruitmentToUpdate.CandidateID = updateDto.CandidateID;
			recruitmentToUpdate.Candidate = candidate;
		}

		if (recruitmentToUpdate.RecruiterID != updateDto.RecruiterID)
		{
			var recruiter = await _employeeCRUDService
				.GetById(updateDto.RecruiterID);

			if (recruiter is null)
			{
				return NotFound($"No {nameof(recruiter)} with Id = {updateDto.RecruiterID} was found in DB");
			}

			recruitmentToUpdate.RecruiterID = updateDto.RecruiterID;
			recruitmentToUpdate.Recruiter = recruiter;
		}

		recruitmentToUpdate.Status = updateDto.Status;

		try
		{
			await _recruitmentCRUDService.Update(recruitmentToUpdate);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");

			throw;
		}

		return Ok(_mapper.Map<RecruitmentReadDto>(recruitmentToUpdate));
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<RecruitmentReadDto>> DeleteRecruitment(int id)
	{
		var recruitmentToDelete = await _recruitmentCRUDService.GetById(id);

		if (recruitmentToDelete is null)
		{
			return NotFound();
		}

		await _recruitmentCRUDService.Delete(id);

		return Ok(_mapper.Map<RecruitmentReadDto>(recruitmentToDelete));
	}
}
