using AutoMapper;
using DatabaseService.Dtos;
using DatabaseService.Model;

namespace DatabaseService.Profiles;

public class CandidateProfile : Profile
{
	public CandidateProfile()
	{
		CreateMap<Candidate, CandidateReadDto>();
		CreateMap<CandidateCreateDto, Candidate>();
	}
}
