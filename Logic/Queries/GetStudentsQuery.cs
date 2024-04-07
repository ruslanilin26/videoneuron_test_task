using Data;
using Data.Models;
using Logic.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Queries;

public class GetStudentsQuery: IRequest<IList<StudentDto>> { }

public class GetStudentsQueryHandler(ApplicationContext applicationContext)
    : IRequestHandler<GetStudentsQuery, IList<StudentDto>>
{
    public async Task<IList<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await applicationContext.Students.Select(student => new StudentDto
        { 
            StudentId = student.StudentId,
            Name = student.Name,
            Surname = student.Surname
        }).ToListAsync(cancellationToken);
        
        return students;
    }
}