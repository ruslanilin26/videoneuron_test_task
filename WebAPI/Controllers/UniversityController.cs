using Logic.Commands;
using Logic.DTO;
using Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UniversityController(IMediator mediator) : ControllerBase
{
    [HttpPost("CreateUniversity")]
    public async Task<IActionResult> CreateUniversity(CreationUniversityDto request)
    {
        await mediator.Send(new CreateUniversityCommand(request));
        return Ok();
    }
    
    [HttpGet("GetUniversities")]
    public async Task<IList<UniversityDto>> GetUniversities()
    {
        var universities = await mediator.Send(new GetUniversitiesQuery());
        return universities;
    }
}