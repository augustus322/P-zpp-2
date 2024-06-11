using DatabaseService.Model;

namespace DatabaseService.Dtos;

public class RecruitmentReadDto
{
	public int ID { get; set; }
	public int CandidateID { get; set; }
	public int RecruiterID { get; set; }
	public RecruitmentStatus Status { get; set; }
}
