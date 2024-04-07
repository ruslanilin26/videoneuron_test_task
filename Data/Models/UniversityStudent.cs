namespace Data.Models;

public class UniversityStudent
{
    public int UniversityStudentId { get; set; }
    
    //FK - UniversityId
    public int UniversityId { get; set; }
    public University University { get; set; } = null!;
    
    //FK - StudentId
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}