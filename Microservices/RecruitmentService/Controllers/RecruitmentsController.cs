using Microsoft.AspNetCore.Mvc;
using RecruitmentService.Connectors;
using RecruitmentService.Dtos;
using RecruitmentService.Model;

namespace RecruitmentService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecruitmentsController : ControllerBase
{
	private readonly IDatabaseConnector _databaseConnector;

	public RecruitmentsController(IDatabaseConnector databaseConnector)
	{
		_databaseConnector = databaseConnector;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<RecruitmentReadDto>>> GetAllRecruitments()
	{
		IOrderedEnumerable<RecruitmentReadDto> recruitments;

		try
		{
			var result = await _databaseConnector.GetRecruitmentsAsync();

			if (!result.IsSuccess)
			{
				throw result.Error!;
			}

			recruitments = result.Result!.OrderBy(r => r.ID);
		}
		catch (Exception ex)
		{
			throw;
		}

		return Ok(recruitments);
	}

	[HttpGet("{id}", Name = "GetRecruitmentById")]
	public async Task<ActionResult<RecruitmentReadDto>> GetRecruitmentById(int id)
	{
		ResultObject<RecruitmentReadDto> result;

		try
		{
			result = await _databaseConnector.GetRecruitmentAsync(id);
		}
		catch (Exception ex)
		{
			return NotFound();
		}

		if (!result.IsSuccess)
		{
			return NotFound();
		}

		return Ok(result.Result!);
	}

	[HttpPost]
	public async Task<ActionResult<RecruitmentReadDto>> AddRecruitment([FromBody] RecruitmentCreateDto createDto)
	{
		var result = await _databaseConnector.CreateRecruitmentAsync(createDto);

		if (!result.IsSuccess)
		{
			return BadRequest();
		}

		var createdRecruitment = result.Result!;

		return CreatedAtRoute(nameof(GetRecruitmentById), new { id = createdRecruitment.ID }, createdRecruitment);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<RecruitmentReadDto>> EditRecruitment(int id, RecruitmentCreateDto updateDto)
	{
		ResultObject<RecruitmentReadDto> result;

		try
		{
			result = await _databaseConnector.UpdateRecruitmentAsync(updateDto, id);
		}
		catch (Exception ex)
		{
			return NotFound();
		}

		if (!result.IsSuccess)
		{
			return BadRequest(result.Error);
		}

		return Ok(result.Result!);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<RecruitmentReadDto>> DeleteRecruitment(int id)
	{
		ResultObject<RecruitmentReadDto> result;

		try
		{
			result = await _databaseConnector.DeleteRecruitmentAsync(id);
		}
		catch (Exception ex)
		{
			return NotFound();
		}

		if (!result.IsSuccess)
		{
			return BadRequest(result.Error);
		}

		return Ok(result.Result!);
	}
}
