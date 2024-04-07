using Data;
using Data.Models;
using Logic.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Commands;

public class CreateStudentCommand(CreationStudentDto creationStudentDto) : IRequest
{
    public string Name { get; } = creationStudentDto.Name;
    public string Surname { get; } = creationStudentDto.Surname;
}

public class CreateStudentCommandHandler(ApplicationContext applicationContext) : IRequestHandler<CreateStudentCommand>
{
    public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var newStudent = new Student()
        {
            Name = request.Name,
            Surname = request.Surname
        };
        
        await applicationContext.Students.AddAsync(newStudent, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }
}