using Logic.Commands;
using Logic.DTO;
using Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(IMediator mediator) : ControllerBase
{
    [HttpPost("CreateStudent")]
    public async Task<IActionResult> CreateStudent(CreationStudentDto request)
    {
        await mediator.Send(new CreateStudentCommand(request));
        return Ok();
    }
    
    [HttpPost("AddStudentToUniversity")]
    public async Task<IActionResult> AddStudentToUniversity(AddStudentToUniversityDto request)
    {
        await mediator.Send(new AddStudentToUniversityCommand(request));
        return Ok();    
    }
    
    [HttpPost("AddStudentToGroup")]
    public async Task<IActionResult> AddStudentToGroup(AddStudentToGroupDto request)
    {
        await mediator.Send(new AddStudentToGroupCommand(request));
        return Ok();    
    }
    
    [HttpGet("GetStudents")]
    public async Task<IList<StudentDto>> GetStudents()
    {
        var students = await mediator.Send(new GetStudentsQuery());
        return students;
    }
    [HttpGet("GetStudentsAtUniversity")]
    public async Task<IList<StudentDto>> GetStudentsAtUniversity(int universityId)
    {
        var students = await mediator.Send(new GetStudentsAtUniversityQuery(universityId));
        return students;
    }
    [HttpGet("GetStudentsInUniversityGroup")]
    public async Task<IList<StudentDto>> GetStudentsInUniversityGroup(int groupId )
    {
        var students = await mediator.Send(new GetStudentsInUniversityGroupQuery(groupId));
        return students;
    }
}