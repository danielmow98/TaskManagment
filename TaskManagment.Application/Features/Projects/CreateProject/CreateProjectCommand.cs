namespace TaskManagment.Application.Features.Projects.CreateProject;

public record CreateProjectCommand(
    string Name,
    string Description,
    Guid CreatedByUserId);