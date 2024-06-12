using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;

namespace DatabaseService.Profiles;

public class SalaryProfile : Profile
{
	public SalaryProfile()
	{
		CreateMap<Salary, SalaryReadDto>();
		CreateMap<SalaryCreateDto, Salary>();
	}
}
