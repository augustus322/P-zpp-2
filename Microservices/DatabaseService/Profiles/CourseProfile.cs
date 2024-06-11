using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;

namespace DatabaseService.Profiles;

public class CourseProfile : Profile
{
	public CourseProfile()
	{
		CreateMap<Course, CourseReadDto>();
		CreateMap<CourseCreateDto, Course>();
	}
}
