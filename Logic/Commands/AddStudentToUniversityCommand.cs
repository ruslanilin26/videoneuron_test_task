using Data;
using Data.Models;
using Logic.DTO;
using Logic.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Commands;

public class AddStudentToUniversityCommand(AddStudentToUniversityDto addStudentToUniversityDto) : IRequest
{
    public int StudentId { get; } = addStudentToUniversityDto.StudentId;
    public int UniversityId { get; } = addStudentToUniversityDto.UniversityId;
}
public class AddStudentToUniversityCommandHandler(ApplicationContext applicationContext)
    : IRequestHandler<AddStudentToUniversityCommand>
{
    public async Task Handle(AddStudentToUniversityCommand request, CancellationToken cancellationToken)
    {
        //Проверяем есть ли такой университет или студент
        var university = await applicationContext.Universities.AnyAsync(u => u.UniversityId == request.UniversityId, cancellationToken);
        
        if (!university)
            throw new NotFoundException($"Университет с id={request.UniversityId} не сущетсвует");
        
        var student = await applicationContext.Students.AnyAsync(s => s.StudentId == request.StudentId, cancellationToken);
        
        if (!student)
            throw new NotFoundException($"Студент с id={request.StudentId} не сущетсвует");
        
        //Проверяем есть ли такой студент в университете
        var studentInUniversity = await applicationContext.UniversityStudents
            .AnyAsync(us =>
                (us.StudentId == request.StudentId) && 
                (us.UniversityId == request.UniversityId), cancellationToken);
        
        if (studentInUniversity) 
            throw new AlreadyExistsException($"Студент с id={request.StudentId} уже есть в университете");
        
        //Добавляем студента в университет
        var newStudentToUniversity = new UniversityStudent()
        {
            StudentId = request.StudentId,
            UniversityId = request.UniversityId
        };
                
        await applicationContext.UniversityStudents.AddAsync(newStudentToUniversity, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }
}