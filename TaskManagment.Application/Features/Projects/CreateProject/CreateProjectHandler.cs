using TaskManagment.Application.DTOs;
using TaskManagment.Application.Interfaces;
using TaskManagment.Domain.Entities;

namespace TaskManagment.Application.Features.Projects.CreateProject;

public class CreateProjectHandler
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public CreateProjectHandler(
        IProjectRepository projectRepository,
        IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public async Task<CreateProjectResult> HandleAsync(CreateProjectCommand command)
    {
        var user = await _userRepository.GetByIdAsync(command.CreatedByUserId) ?? throw new InvalidOperationException("User not found");

        var project = new Project(command.Name, command.Description);
        project.AddUser(user);
        
        await _projectRepository.AddAsync(project);
        
        var dto = new ProjectDto(project.Id, project.Name, project.Description);
        return new CreateProjectResult(dto);
    }
}