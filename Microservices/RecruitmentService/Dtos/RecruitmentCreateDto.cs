namespace RecruitmentService.Dtos;

public class RecruitmentCreateDto
{
	public int CandidateID { get; set; }
	public int RecruiterID { get; set; }
	public RecruitmentStatus Status { get; set; }
}
