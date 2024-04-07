namespace Data.Models;

public class Group
{
    public int GroupId { get; set; }
    public string Name { get; set; } = null!;
    
    //FK - UniversityId
    public int UniversityId { get; set; }
    public University University { get; set; } = null!;
    
    // GroupId -> FK в GroupStudent
    public ICollection<GroupStudent> GroupStudents { get; set; } = null!;
}