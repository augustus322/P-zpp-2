using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;

namespace DatabaseService.Profiles;

public class TimeOffProfile : Profile
{
	public TimeOffProfile()
	{
		CreateMap<TimeOff, TimeOffReadDto>();
		CreateMap<TimeOffCreateDto, TimeOff>();
	}
}
