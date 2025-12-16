using TaskManagment.Application.Interfaces;

namespace TaskManagment.Application.Features.Tasks;

public class ChangeTaskStatusHandler
{
    private readonly ITaskRepository _tasks;
    
    public ChangeTaskStatusHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public async Task HandleAsync(ChangeTaskStatusCommand command)
    {
        var task = await _tasks.GetByIdAsync(command.TaskId) ?? throw new InvalidOperationException("Task not found");
        task.ChangeStatus(command.NewStatus);
    }
}