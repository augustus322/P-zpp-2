using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalariesController : ControllerBase
{
	private readonly SalaryCRUDService _salaryCRUDService;
	private readonly EmployeeCRUDService _employeeCRUDService;
	private readonly IMapper _mapper;

	public SalariesController(SalaryCRUDService salaryCRUDService,
		IMapper mapper,
		EmployeeCRUDService employeeCRUDService)
	{
		_salaryCRUDService = salaryCRUDService;
		_mapper = mapper;
		_employeeCRUDService = employeeCRUDService;
	}

	[HttpGet]
	public ActionResult<IEnumerable<SalaryReadDto>> GetAllSalaries()
	{
		IOrderedEnumerable<Salary> salaries;

		try
		{
			salaries = _salaryCRUDService.GetAll()
				.ToList().OrderBy(c => c.ID);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{nameof(salaries)} could not be fetched from DB, error msg: {ex.Message}");
			throw;
		}

		return Ok(_mapper.Map<IEnumerable<SalaryReadDto>>(salaries));
	}

	[HttpGet("{id}", Name = "GetSalaryById")]
	public async Task<ActionResult<SalaryReadDto>> GetSalaryById(int id)
	{
		var salary = await _salaryCRUDService.GetById(id);

		if (salary is null)
		{
			return NotFound();
		}

		return Ok(_mapper.Map<SalaryReadDto>(salary));
	}

	[HttpPost]
	public async Task<ActionResult<SalaryCreateDto>> CreateSalary([FromBody] SalaryCreateDto createDto)
	{
		if (createDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createDto)));
		}

		var salaryToCreate = _mapper.Map<Salary>(createDto);

		var employee = await _employeeCRUDService.GetById(salaryToCreate.EmployeeID);

		if (employee is null)
		{
			return NotFound($"No {nameof(employee)} with Id = {salaryToCreate.EmployeeID} was found in DB");
		}

		salaryToCreate.Employee = employee;

		var createdSalary = await _salaryCRUDService.AddAsync(salaryToCreate);

		var salaryReadDto = _mapper.Map<SalaryReadDto>(createdSalary);

		return CreatedAtRoute(nameof(GetSalaryById), new { id = salaryReadDto.ID }, salaryReadDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<SalaryReadDto>> UpdateSalary(int id, SalaryCreateDto updateDto)
	{
		var salaryToUpdate = await _salaryCRUDService.GetById(id);

		if (salaryToUpdate is null)
		{
			return NotFound();
		}

		if (salaryToUpdate.EmployeeID != updateDto.EmployeeID)
		{
			var employee = await _employeeCRUDService.GetById(updateDto.EmployeeID);

			if (employee is null)
			{
				return NotFound($"No {nameof(employee)} with Id = {updateDto.EmployeeID} was found in DB");
			}

			salaryToUpdate.EmployeeID = updateDto.EmployeeID; 
			salaryToUpdate.Employee = employee;
		}

		salaryToUpdate.Amount = updateDto.Amount;
		salaryToUpdate.PaymentDate = updateDto.PaymentDate;

		try
		{
			await _salaryCRUDService.Update(salaryToUpdate);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");

			throw;
		}

		return Ok(_mapper.Map<SalaryReadDto>(salaryToUpdate));
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<SalaryReadDto>> DeleteSalary(int id)
	{
		var salaryToDelete = await _salaryCRUDService.GetById(id);

		if (salaryToDelete is null)
		{
			return NotFound();
		}

		await _salaryCRUDService.Delete(id);

		return Ok(_mapper.Map<SalaryReadDto>(salaryToDelete));
	}
}
