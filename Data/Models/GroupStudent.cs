namespace Data.Models;

public class GroupStudent
{
    public int GroupStudentId { get; set; }
    
    //FK - GroupId
    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
    
    //FK - StudentId
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}