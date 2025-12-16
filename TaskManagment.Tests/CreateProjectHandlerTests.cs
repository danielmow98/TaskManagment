using FluentAssertions;
using Moq;
using TaskManagment.Application.Features.Projects.CreateProject;
using TaskManagment.Application.Interfaces;
using TaskManagment.Domain.Entities;
using TaskManagment.Domain.Enums;
using Xunit;


namespace TaskManagment.Tests;

public class CreateProjectHandlerTests
{
    [Fact]
    public async Task Creates_project_and_assigns_user()
    {
        var user = new User("test@test.com", "hash", UserRole.User);
        var userRepo = new Mock<IUserRepository>();
        userRepo.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);
        
        var projectRepo = new Mock<IProjectRepository>();
        
        var handler  = new CreateProjectHandler(projectRepo.Object, userRepo.Object);
        
        var command = new CreateProjectCommand("Test Project", "Description", Guid.NewGuid());
        var result = await handler.HandleAsync(command);
        result.Project.Name.Should().Be("Test Project");
        projectRepo.Verify(x => x.AddAsync(It.IsAny<Project>()), Times.Once);
    }
}