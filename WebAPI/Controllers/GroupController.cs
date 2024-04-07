using Logic.Commands;
using Logic.DTO;
using Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController(IMediator mediator) : ControllerBase
{
    [HttpPost("CreateGroup")]
    public async Task<IActionResult> CreateGroup(CreationGroupDto request)
    {
        await mediator.Send(new CreateGroupCommand(request));
        return Ok();
    }
    
    [HttpGet("GetGroups")]
    public async Task<IList<GroupDto>> GetGroups()
    {
        var groups = await mediator.Send(new GetGroupsQuery());
        return groups;
    }
    [HttpGet("GetGroupsAtUniversity")]
    public async Task<IList<GroupDto>> GetGroupsAtUniversity(int universityId)
    {
        var groups = await mediator.Send(new GetGroupsAtUniversityQuery(universityId));
        return groups;
    }
}