using Data;
using Data.Models;
using Logic.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Queries;

public class GetGroupsAtUniversityQuery(int universityId) : IRequest<IList<GroupDto>>
{
    public int UniversityId { get; } = universityId;
}

public class GetGroupsAtUniversityQueryHandler(ApplicationContext applicationContext)
    : IRequestHandler<GetGroupsAtUniversityQuery, IList<GroupDto>>
{
    public async Task<IList<GroupDto>> Handle(GetGroupsAtUniversityQuery request, CancellationToken cancellationToken)
    {
        var groups = await applicationContext.Groups
            .Where(group => group.UniversityId == request.UniversityId)
            .Select(group => new GroupDto
            {
                GroupId = group.GroupId,
                Name = group.Name
            }).ToListAsync(cancellationToken);
        
        return groups;
    }
}