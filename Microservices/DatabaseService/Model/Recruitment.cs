namespace DatabaseService.Model;

public enum RecruitmentStatus
{
    Pending,
    Approved,
    Denied
}

public class Recruitment
{
    public int ID { get; set; }
    public int CandidateID { get; set; }
    public Candidate Candidate { get; set; }
    public int RecruiterID { get; set; }
    public Employee Recruiter { get; set; }
    public RecruitmentStatus Status { get; set; }
}
