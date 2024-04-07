using Data;
using Data.Models;
using Logic.DTO;
using Logic.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Commands;

public class AddStudentToGroupCommand(AddStudentToGroupDto addStudentToGroupDto) : IRequest
{
    public int StudentId { get; } = addStudentToGroupDto.StudentId;
    public int GroupId { get; } = addStudentToGroupDto.GroupId;
}

public class AddStudentToGroupCommandHandler(ApplicationContext applicationContext)
    : IRequestHandler<AddStudentToGroupCommand>
{
    public async Task Handle(AddStudentToGroupCommand request, CancellationToken cancellationToken)
    {
        //Проверяем существуют ли такая группа или студент
        var group = await applicationContext.Groups
            .FirstOrDefaultAsync(g => g.GroupId == request.GroupId, cancellationToken);
        if (group == null) 
            throw new NotFoundException($"Группа с id={request.GroupId} не сущетсвует");
        
        var student = await applicationContext.Students
            .AnyAsync(s => s.StudentId == request.StudentId, cancellationToken);
        if (!student) 
            throw new NotFoundException($"Cтудент с id={request.StudentId} не сущетсвует");
        
        //Проверяем есть ли такой студент в групее
        var studentInGroup = await applicationContext.GroupStudents
            .AnyAsync(gs => 
                (gs.StudentId == request.StudentId) && 
                (gs.GroupId == request.GroupId), cancellationToken);
        
        if (studentInGroup)
            throw new AlreadyExistsException($"В этой группе уже есть студент с id={request.StudentId}");
        
        //Проверяем есть ли такой студент в университете
        var belongsToUniversity = await applicationContext.UniversityStudents
            .AnyAsync(us => 
                us.StudentId == request.StudentId && 
                us.UniversityId == group.UniversityId, cancellationToken);

        if (!belongsToUniversity) 
            throw new NotFoundException("Данного студента нет в этом университете");
        
        //Добавляем студента в группу
        var newStudentInGroup = new GroupStudent
        {
            GroupId = request.GroupId,
            StudentId = request.StudentId
        };

        await applicationContext.GroupStudents.AddAsync(newStudentInGroup, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }
}