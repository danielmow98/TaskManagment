using TaskManagment.Application.Interfaces;
using TaskManagment.Domain.Entities;

namespace TaskManagment.Application.Features.Tasks;

public class CreateTaskHandler
{
    private readonly IProjectRepository _projects;
    private readonly ITaskRepository _tasks;

    public CreateTaskHandler(
        IProjectRepository projects,
        ITaskRepository tasks)
    {
        _projects = projects;
        _tasks = tasks;
    }

    public async Task<Guid> Handle(CreateTaskCommand command)
    {
        var project = await _projects.GetByIdAsync(command.ProjectId) ??
                      throw new InvalidOperationException("Project not found");
        if (!project.Users.Any(u => u.Id == command.CreatedByUserId))
            throw new UnauthorizedAccessException("User not in Project");
        var task = new TaskItem(
            command.Title,
            command.Description,
            command.DueDate,
            command.Priority);
        
        project.AddTask(task);
        await _tasks.AddAsync(task);
        
        return task.Id;
    }
}