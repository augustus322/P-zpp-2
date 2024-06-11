using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class RecruitmentCreateDto
{
	public Candidate Candidate { get; set; }
	public Employee Recruiter { get; set; }
	public RecruitmentStatus Status { get; set; }
}
