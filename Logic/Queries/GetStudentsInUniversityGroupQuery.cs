using Data;
using Logic.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Queries;

public class GetStudentsInUniversityGroupQuery(int groupId) : IRequest<IList<StudentDto>>
{
    public int GroupId { get; } = groupId;
}

public class GetStudentsInUniversityGroupQueryHandler(ApplicationContext applicationContext)
    : IRequestHandler<GetStudentsInUniversityGroupQuery, IList<StudentDto>>
{
    public async Task<IList<StudentDto>> Handle(GetStudentsInUniversityGroupQuery request, CancellationToken cancellationToken)
    {
        var students = await applicationContext.GroupStudents
            .Where(gs => gs.GroupId == request.GroupId)
            .Select(gs => new StudentDto
            {
                StudentId = gs.Student.StudentId,
                Name = gs.Student.Name,
                Surname = gs.Student.Surname
            }).ToListAsync(cancellationToken);
        
        return students;
    }
}