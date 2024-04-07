using Data;
using Data.Models;
using Logic.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Queries;

public class GetStudentsAtUniversityQuery(int universityId) : IRequest<IList<StudentDto>>
{
    public int UniversityId { get; } = universityId;
}

public class GetStudentsAtUniversityQueryHandler(ApplicationContext applicationContext)
    : IRequestHandler<GetStudentsAtUniversityQuery, IList<StudentDto>>
{
    public async Task<IList<StudentDto>> Handle(GetStudentsAtUniversityQuery request, CancellationToken cancellationToken)
    {
        var students = await applicationContext.UniversityStudents
            .Where(us => us.UniversityId == request.UniversityId)
            .Select(us => new StudentDto
                {
                    StudentId = us.Student.StudentId,
                    Name = us.Student.Name,
                    Surname = us.Student.Surname
                }).ToListAsync(cancellationToken);
        
        return students;
    }
}