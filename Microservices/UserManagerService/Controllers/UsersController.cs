using Microsoft.AspNetCore.Mvc;
using UserManagerService.Connectors;
using UserManagerService.Dtos;
using UserManagerService.Model;

namespace UserManagerService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
	private readonly IDatabaseConnector _databaseConnector;

	public UsersController(IDatabaseConnector databaseConnector)
	{
		_databaseConnector = databaseConnector;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
	{
		IOrderedEnumerable<UserReadDto> users;

		try
		{
			var result = await _databaseConnector.GetUsersAsync();

			if (!result.IsSuccess)
			{
				throw result.Error!;
			}

			users = result.Result!.OrderBy(u => u.ID);
		}
		catch (Exception ex)
		{
			throw;
		}

		return Ok(users);
	}

	[HttpGet("{id}", Name = "GetUserById")]
	public async Task<ActionResult<UserReadDto>> GetUserById(int id)
	{
		ResultObject<UserReadDto> result;

		try
		{
			result = await _databaseConnector.GetUserAsync(id);
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
	public async Task<ActionResult<UserReadDto>> AddUser([FromBody] UserCreateDto createDto)
	{
		var result = await _databaseConnector.CreateUserAsync(createDto);

		if (!result.IsSuccess)
		{
			return BadRequest();
		}

		var createdUser = result.Result!;

		return CreatedAtRoute(nameof(GetUserById), new { id = createdUser.ID }, createdUser);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<UserReadDto>> EditUser(int id, UserCreateDto updateDto)
	{
		ResultObject<UserReadDto> result;

		try
		{
			result = await _databaseConnector.UpdateUserAsync(updateDto, id);
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
	public async Task<ActionResult<UserReadDto>> DeleteUser(int id)
	{
		ResultObject<UserReadDto> result;

		try
		{
			result = await _databaseConnector.DeleteUserAsync(id);
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
