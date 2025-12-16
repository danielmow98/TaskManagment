using TaskManagment.Domain.Enums;

namespace TaskManagment.Application.Features.Tasks;

public record ChangeTaskStatusCommand(Guid TaskId, TaskManagment.Domain.Enums.TaskStatus NewStatus, Guid UserId);