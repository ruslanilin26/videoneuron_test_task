namespace Data.Models;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    
    // StudentId -> FK в UniversityStudent
    public ICollection<UniversityStudent> UniversityStudents { get; set; } = null!;
    
    // StudentId -> FK в GroupStudent
    public ICollection<GroupStudent> GroupStudents { get; set; } = null!;
}