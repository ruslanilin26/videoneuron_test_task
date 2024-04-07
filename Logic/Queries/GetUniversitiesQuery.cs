using Data;
using Data.Models;
using Logic.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Queries;

public class GetUniversitiesQuery: IRequest<IList<UniversityDto>> { }

public class GetAdminFilmQueryHandler(ApplicationContext applicationContext)
    : IRequestHandler<GetUniversitiesQuery, IList<UniversityDto>>
{
    public async Task<IList<UniversityDto>> Handle(GetUniversitiesQuery request, CancellationToken cancellationToken)
    {
        var universities = await applicationContext.Universities.Select(university => new UniversityDto
            {
                UniversityId = university.UniversityId,
                Name = university.Name,
                City = university.City
            }).ToListAsync(cancellationToken);
        
        return universities;
    }
}