namespace TaskManagment.Application.DTOs;

public record CreateProjectRequest(
    string Name,
    string Description);