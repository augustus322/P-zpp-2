using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeOffsController : ControllerBase
{
	private readonly TimeOffCRUDService _timeOffCRUDService;
	private readonly EmployeeCRUDService _employeeCRUDService;
	private readonly IMapper _mapper;

	public TimeOffsController(TimeOffCRUDService timeOffCRUDService,
		IMapper mapper,
		EmployeeCRUDService employeeCRUDService)
	{
		_timeOffCRUDService = timeOffCRUDService;
		_mapper = mapper;
		_employeeCRUDService = employeeCRUDService;
	}

	[HttpGet]
	public ActionResult<IEnumerable<TimeOffReadDto>> GetAllTimeOffs()
	{
		IOrderedEnumerable<TimeOff> timeOffs;

		try
		{
			timeOffs = _timeOffCRUDService.GetAll()
				.ToList().OrderBy(c => c.ID);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{nameof(timeOffs)} could not be fetched from DB, error msg: {ex.Message}");
			throw;
		}

		return Ok(_mapper.Map<IEnumerable<TimeOffReadDto>>(timeOffs));
	}

	[HttpGet("{id}", Name = "GetTimeOffById")]
	public async Task<ActionResult<TimeOffReadDto>> GetTimeOffById(int id)
	{
		var timeOff = await _timeOffCRUDService.GetById(id);

		if (timeOff is null)
		{
			return NotFound();
		}

		return Ok(_mapper.Map<TimeOffReadDto>(timeOff));
	}

	[HttpPost]
	public async Task<ActionResult<TimeOffCreateDto>> CreateTimeOff([FromBody] TimeOffCreateDto createDto)
	{
		if (createDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createDto)));
		}

		var timeOffToCreate = _mapper.Map<TimeOff>(createDto);

		var employee = await _employeeCRUDService
			.GetById(timeOffToCreate.EmployeeID);

		if (employee is null)
		{
			return NotFound($"No {nameof(employee)} with Id = {timeOffToCreate.EmployeeID} was found in DB");
		}

		timeOffToCreate.Employee = employee;

		var createdTimeOff = await _timeOffCRUDService.AddAsync(timeOffToCreate);

		var timeOffReadDto = _mapper.Map<TimeOffReadDto>(createdTimeOff);

		return CreatedAtRoute(nameof(GetTimeOffById), new { id = timeOffReadDto.ID }, timeOffReadDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<TimeOffReadDto>> UpdateTimeOff(int id, TimeOffCreateDto updateDto)
	{
		var timeOffToUpdate = await _timeOffCRUDService.GetById(id);

		if (timeOffToUpdate is null)
		{
			return NotFound();
		}

		if (timeOffToUpdate.EmployeeID != updateDto.EmployeeID)
		{
			var employee = await _employeeCRUDService
				.GetById(updateDto.EmployeeID);

			if (employee is null)
			{
				return NotFound($"No {nameof(employee)} with Id = {updateDto.EmployeeID} was found in DB");
			}

			timeOffToUpdate.EmployeeID = updateDto.EmployeeID;
			timeOffToUpdate.Employee = employee;
		}

		timeOffToUpdate.StartDate = updateDto.StartDate;
		timeOffToUpdate.EndDate = updateDto.EndDate;
		timeOffToUpdate.Status = updateDto.Status;

		try
		{
			await _timeOffCRUDService.Update(timeOffToUpdate);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");

			throw;
		}

		return Ok(_mapper.Map<TimeOffReadDto>(timeOffToUpdate));
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<TimeOffReadDto>> DeleteTimeOff(int id)
	{
		var timeOffToDelete = await _timeOffCRUDService.GetById(id);

		if (timeOffToDelete is null)
		{
			return NotFound();
		}

		await _timeOffCRUDService.Delete(id);

		return Ok(_mapper.Map<TimeOffReadDto>(timeOffToDelete));
	}
}
