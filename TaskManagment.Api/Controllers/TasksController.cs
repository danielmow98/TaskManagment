using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.Features.Tasks;
using TaskManagment.Application.Features.Comments;

namespace TaskManagment.Controllers;

[ApiController]
[Route("api/tasks")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly CreateTaskHandler _createTask;
    private readonly ChangeTaskStatusHandler _changeStatus;
    private readonly AddCommentHandler _addComment;

    private readonly CreateTaskValidator _createTaskValidator;
    private readonly AddCommentValidator _addCommentValidator;

    public TasksController(
        CreateTaskHandler createTask,
        ChangeTaskStatusHandler changeStatus,
        AddCommentHandler addComment,
        CreateTaskValidator createTaskValidator,
        AddCommentValidator addCommentValidator)
    {
        _createTask = createTask;
        _changeStatus = changeStatus;
        _addComment = addComment;
        _createTaskValidator = createTaskValidator;
        _addCommentValidator = addCommentValidator;
    }

    // POST /api/tasks
    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskCommand command)
    {
        command = command with { CreatedByUserId = GetUserId() };

        var validation = await _createTaskValidator.ValidateAsync(command);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        var taskId = await _createTask.Handle(command);
        return CreatedAtAction(nameof(Create), new { id = taskId }, null);
    }

    // PATCH /api/tasks/{id}/status
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> ChangeStatus(
        Guid id,
        [FromBody] ChangeTaskStatusCommand command)
    {
        command = command with
        {
            TaskId = id,
            UserId = GetUserId()
        };

        await _changeStatus.HandleAsync(command);
        return NoContent();
    }

    // POST /api/tasks/{id}/comments
    [HttpPost("{id}/comments")]
    public async Task<IActionResult> AddComment(
        Guid id,
        AddCommentCommand command)
    {
        command = command with
        {
            TaskId = id,
            UserId = GetUserId()
        };

        var validation = await _addCommentValidator.ValidateAsync(command);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        await _addComment.HandleAsync(command);
        return Ok();
    }

    private Guid GetUserId()
    {
        var userId = User.FindFirst("sub")?.Value;
        if (userId is null)
            throw new UnauthorizedAccessException();

        return Guid.Parse(userId);
    }
}