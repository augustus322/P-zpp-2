using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;

namespace DatabaseService.Profiles;

public class EmployeeProfile : Profile
{
	public EmployeeProfile()
	{
		CreateMap<Employee, EmployeeReadDto>();
		CreateMap<EmployeeCreateDto, Employee>();
	}
}
