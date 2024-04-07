using Data;
using Data.Models;
using Logic.DTO;
using Logic.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Commands;

public class CreateUniversityCommand(CreationUniversityDto creationUniversityDto) : IRequest
{
    public string Name { get; } = creationUniversityDto.Name;
    public string City { get; } = creationUniversityDto.City;
}

public class CreateUniversityCommandHandler(ApplicationContext applicationContext)
    : IRequestHandler<CreateUniversityCommand>
{
    public async Task Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
    {
        var university = await applicationContext.Universities
            .AnyAsync(u =>
                u.Name.ToLower().Equals(request.Name.ToLower()) &&
                u.City.ToLower().Equals(request.City.ToLower()), cancellationToken);

        if (!university) 
            throw new AlreadyExistsException($"Университете с именем '{request.Name}' уже существует в городе {request.City}");
        
        var newUniversity = new University()
        {
            Name = request.Name,
            City = request.City
        };
            
        await applicationContext.Universities.AddAsync(newUniversity, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }
}