using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public sealed class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<University> Universities { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<UniversityStudent> UniversityStudents { get; set; } = null!;
    public DbSet<GroupStudent> GroupStudents { get; set; } = null!;
}