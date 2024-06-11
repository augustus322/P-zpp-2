namespace DatabaseService.Model;

public class Candidate
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public ICollection<Recruitment> Recruitments { get; set; } = new List<Recruitment>();
}
