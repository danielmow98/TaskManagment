using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.Features.Projects.CreateProject;
using TaskManagment.Application.Validation;

namespace TaskManagment.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly CreateProjectHandler _handler;
    private readonly CreateProjectValidator _validator;
    
    public ProjectsController(CreateProjectHandler handler, CreateProjectValidator validator)
    {
        _handler = handler;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);
        if(!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        var result = await _handler.HandleAsync(command);
        return CreatedAtAction(nameof(Create), result.Project);
    }
}