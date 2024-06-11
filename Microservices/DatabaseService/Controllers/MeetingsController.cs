using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeetingsController : ControllerBase
{
	private readonly MeetingCRUDService _meetingCRUDService;
	private readonly IMapper _mapper;

	public MeetingsController(MeetingCRUDService meetingCRUDService,
		IMapper mapper)
	{
		_meetingCRUDService = meetingCRUDService;
		_mapper = mapper;
	}

	[HttpGet]
	public ActionResult<IEnumerable<MeetingReadDto>> GetAllMeetings()
	{
		IOrderedEnumerable<Meeting> meetings;

		try
		{
			meetings = _meetingCRUDService.GetAll()
				.ToList().OrderBy(c => c.ID);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{nameof(meetings)} could not be fetched from DB, error msg: {ex.Message}");
			throw;
		}

		return Ok(_mapper.Map<IEnumerable<MeetingReadDto>>(meetings));
	}

	[HttpGet("{id}", Name = "GetMeetingById")]
	public async Task<ActionResult<MeetingReadDto>> GetMeetingById(int id)
	{
		var meeting = await _meetingCRUDService.GetById(id);

		if (meeting is null)
		{
			return NotFound();
		}

		return Ok(_mapper.Map<MeetingReadDto>(meeting));
	}

	[HttpPost]
	public async Task<ActionResult<MeetingCreateDto>> CreateMeeting([FromBody] MeetingCreateDto createDto)
	{
		if (createDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createDto)));
		}

		var meetingToCreate = _mapper.Map<Meeting>(createDto);

		var createdMeeting = await _meetingCRUDService.AddAsync(meetingToCreate);

		var meetingReadDto = _mapper.Map<MeetingReadDto>(createdMeeting);

		return CreatedAtRoute(nameof(GetMeetingById), new { id = meetingReadDto.ID }, meetingReadDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<MeetingReadDto>> UpdateMeeting(int id, MeetingCreateDto updateDto)
	{
		var meetingToUpdate = await _meetingCRUDService.GetById(id);

		if (meetingToUpdate is null)
		{
			return NotFound();
		}

		meetingToUpdate.Topic = updateDto.Topic;
		meetingToUpdate.Address = updateDto.Address;
		meetingToUpdate.Date = updateDto.Date;

		try
		{
			await _meetingCRUDService.Update(meetingToUpdate);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");

			throw;
		}

		return Ok(_mapper.Map<MeetingReadDto>(meetingToUpdate));
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<MeetingReadDto>> DeleteMeeting(int id)
	{
		var meetingToDelete = await _meetingCRUDService.GetById(id);

		if (meetingToDelete is null)
		{
			return NotFound();
		}

		await _meetingCRUDService.Delete(id);

		return Ok(_mapper.Map<MeetingReadDto>(meetingToDelete));
	}
}
