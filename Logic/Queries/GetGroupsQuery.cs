using Data;
using Data.Models;
using Logic.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Logic.Queries;

public class GetGroupsQuery: IRequest<IList<GroupDto>> { }

public class GetGroupsQueryHandler(ApplicationContext applicationContext)
    : IRequestHandler<GetGroupsQuery, IList<GroupDto>>
{
    public async Task<IList<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        var groups = await applicationContext.Groups.Select(group => new GroupDto
        {
            GroupId = group.GroupId,
            Name = group.Name
        }).ToListAsync(cancellationToken);
        
        return groups;
    }
}