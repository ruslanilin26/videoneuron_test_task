namespace Data.Models;

public class University
{
    public int UniversityId { get; set; }
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    
    // UniversityId -> FK в Group
    public ICollection<Group> Groups { get; set; } = null!;
    
    // UniversityId -> FK в UniversityStudent
    public ICollection<UniversityStudent> UniversityStudents { get; set; } = null!;
}