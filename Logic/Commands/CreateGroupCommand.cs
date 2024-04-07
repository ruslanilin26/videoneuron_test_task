using Data;
using Data.Models;
using Logic.DTO;
using Logic.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Commands;

public class CreateGroupCommand(CreationGroupDto creationGroupDto) : IRequest
{
    public string Name { get; } = creationGroupDto.Name;
    public int UniversityId { get; } = creationGroupDto.UniversityId;
}

public class CreateGroupCommandHandler(ApplicationContext applicationContext) : IRequestHandler<CreateGroupCommand>
{
    public async Task Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        //Проверяем есть ли такой университет
        var university = await applicationContext.Universities
            .AnyAsync(u => u.UniversityId == request.UniversityId, cancellationToken);

        if (!university) 
            throw new NotFoundException($"Университет с id={request.UniversityId} не найден");
        
        //Првоеряем есть ли такая группа
        var group = await applicationContext.Groups
            .AnyAsync(g =>
                (g.Name.ToLower().Equals(request.Name.ToLower())) && 
                (g.UniversityId == request.UniversityId), cancellationToken);

        if (group) 
            throw new AlreadyExistsException($"Группа с именем '{request.Name}' уже существует в университете с id={request.UniversityId}");
        
        //Добавляем группу
        var newGroup = new Group()
        {
            Name = request.Name,
            UniversityId = request.UniversityId
        };
            
        await applicationContext.Groups.AddAsync(newGroup, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }
}