using TaskManagment.Application.Interfaces;
using TaskManagment.Domain.Entities;

namespace TaskManagment.Application.Features.Comments;

public class AddCommentHandler
{
    private readonly ITaskRepository _tasks;
    
    public AddCommentHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public async Task HandleAsync(AddCommentCommand command)
    {
        var task = await _tasks.GetByIdAsync(command.TaskId) ?? throw new InvalidOperationException("Task not found");
        
        var comment = new Comment(command.UserId, command.Content);
        task.AddComment(comment);
    }
}