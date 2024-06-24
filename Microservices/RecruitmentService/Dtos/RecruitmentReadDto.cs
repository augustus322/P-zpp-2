namespace RecruitmentService.Dtos;

public enum RecruitmentStatus
{
	Pending,
	Approved,
	Denied
}

public class RecruitmentReadDto
{
	public int ID { get; set; }
	public int CandidateID { get; set; }
	public int RecruiterID { get; set; }
	public RecruitmentStatus Status { get; set; }
}
