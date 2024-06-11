using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
	private readonly EmployeeCRUDService _employeeCRUDService;
	private readonly IMapper _mapper;

	public EmployeesController(EmployeeCRUDService employeeCRUDService,
		IMapper mapper)
	{
		_employeeCRUDService = employeeCRUDService;
		_mapper = mapper;
	}

	[HttpGet]
	public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
	{
		IOrderedEnumerable<Employee> employees;

		try
		{
			employees = _employeeCRUDService.GetAll()
				.ToList().OrderBy(c => c.ID);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{nameof(employees)} could not be fetched from DB, error msg: {ex.Message}");
			throw;
		}

		return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
	}
	
	[HttpGet("{id}", Name = "GetEmployeeById")]
	public async Task<ActionResult<EmployeeReadDto>> GetEmployeeById(int id)
	{
		var employee = await _employeeCRUDService.GetById(id);

		if (employee is null)
		{
			return NotFound();
		}

		return Ok(_mapper.Map<EmployeeReadDto>(employee));
	}
	
	[HttpPost]
	public async Task<ActionResult<EmployeeReadDto>> CreateEmployee([FromBody] EmployeeCreateDto createDto)
	{
		if (createDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createDto)));
		}

		var employeeToCreate = _mapper.Map<Employee>(createDto);

		var createdEmployee = await _employeeCRUDService.AddAsync(employeeToCreate);

		var employeeReadDto = _mapper.Map<EmployeeReadDto>(createdEmployee);

		return CreatedAtRoute(nameof(GetEmployeeById), new { id = employeeReadDto.ID }, employeeReadDto);
	}
	
	[HttpPut("{id}")]
	public async Task<ActionResult<EmployeeReadDto>> UpdateEmployee(int id, EmployeeCreateDto updateDto)
	{
		var employeeToUpdate = await _employeeCRUDService.GetById(id);

		if (employeeToUpdate is null)
		{
			return NotFound();
		}

		employeeToUpdate.FirstName = updateDto.FirstName;
		employeeToUpdate.LastName = updateDto.LastName;
		employeeToUpdate.Phone = updateDto.Phone;
		employeeToUpdate.Email = updateDto.Email;
		employeeToUpdate.Address = updateDto.Address;
		employeeToUpdate.Position = updateDto.Position;

		try
		{
			await _employeeCRUDService.Update(employeeToUpdate);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");

			throw;
		}

		return Ok(_mapper.Map<EmployeeReadDto>(employeeToUpdate));
	}
	
	[HttpDelete("{id}")]
	public async Task<ActionResult<EmployeeReadDto>> DeleteEmployee(int id)
	{
		var employeeToDelete = await _employeeCRUDService.GetById(id);

		if (employeeToDelete is null)
		{
			return NotFound();
		}

		await _employeeCRUDService.Delete(id);

		return Ok(_mapper.Map<EmployeeReadDto>(employeeToDelete));
	}
}
