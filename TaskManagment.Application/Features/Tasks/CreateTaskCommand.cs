using TaskManagment.Domain.Enums;

namespace TaskManagment.Application.Features.Tasks;

public record CreateTaskCommand(
    Guid ProjectId,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime DueDate,
    TaskPriority Priority,
    Guid CreatedByUserId);