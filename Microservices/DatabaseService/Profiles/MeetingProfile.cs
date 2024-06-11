using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;

namespace DatabaseService.Profiles;

public class MeetingProfile : Profile
{
	public MeetingProfile()
	{
		CreateMap<Meeting, MeetingReadDto>();
		CreateMap<MeetingCreateDto, Meeting>();
	}
}
