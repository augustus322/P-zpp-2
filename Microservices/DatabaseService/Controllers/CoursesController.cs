using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;
using DatabaseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
	private readonly CourseCRUDService _courseCRUDService;
	private readonly IMapper _mapper;

	public CoursesController(CourseCRUDService courseCRUDService,
		IMapper mapper)
	{
		_courseCRUDService = courseCRUDService;
		_mapper = mapper;
	}

	[HttpGet]
	public ActionResult<IEnumerable<CourseReadDto>> GetAllCourses()
	{
		IOrderedEnumerable<Course> courses;

		try
		{
			courses = _courseCRUDService.GetAll()
				.ToList().OrderBy(c => c.ID);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{nameof(courses)} could not be fetched from DB, error msg: {ex.Message}");
			throw;
		}

		return Ok(_mapper.Map<IEnumerable<CourseReadDto>>(courses));
	}

	[HttpGet("{id}", Name = "GetCourseById")]
	public async Task<ActionResult<CourseReadDto>> GetCourseById(int id)
	{
		var course = await _courseCRUDService.GetById(id);

		if (course is null)
		{
			return NotFound();
		}

		return Ok(_mapper.Map<CourseReadDto>(course));
	}

	[HttpPost]
	public async Task<ActionResult<CourseCreateDto>> CreateCourse([FromBody] CourseCreateDto createDto)
	{
		if (createDto is null)
		{
			return BadRequest(new ArgumentNullException(nameof(createDto)));
		}

		var courseToCreate = _mapper.Map<Course>(createDto);

		var createdCourse = await _courseCRUDService.AddAsync(courseToCreate);

		var courseReadDto = _mapper.Map<CourseReadDto>(createdCourse);

		return CreatedAtRoute(nameof(GetCourseById), new { id = courseReadDto.ID }, courseReadDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<CourseReadDto>> UpdateCourse(int id, CourseCreateDto updateDto)
	{
		var courseToUpdate = await _courseCRUDService.GetById(id);

		if (courseToUpdate is null)
		{
			return NotFound();
		}

		courseToUpdate.Topic = updateDto.Topic;
		courseToUpdate.Address = updateDto.Address;
		courseToUpdate.Date = updateDto.Date;

		try
		{
			await _courseCRUDService.Update(courseToUpdate);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");

			throw;
		}

		return Ok(_mapper.Map<CourseReadDto>(courseToUpdate));
	}
	
	[HttpDelete("{id}")]
	public async Task<ActionResult<CourseReadDto>> DeleteCourse(int id)
	{
		var courseToDelete = await _courseCRUDService.GetById(id);

		if (courseToDelete is null)
		{
			return NotFound();
		}

		await _courseCRUDService.Delete(id);

		return Ok(_mapper.Map<CourseReadDto>(courseToDelete));
	}
}
