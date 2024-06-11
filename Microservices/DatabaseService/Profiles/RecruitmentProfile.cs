using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;

namespace DatabaseService.Profiles;

public class RecruitmentProfile : Profile
{
	public RecruitmentProfile()
	{
		CreateMap<Recruitment, RecruitmentReadDto>();
		CreateMap<RecruitmentCreateDto, Recruitment>();
	}
}
