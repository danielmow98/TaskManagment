using TaskManagment.Domain.Common;
using TaskManagment.Domain.Enums;

namespace TaskManagment.Domain.Entities;

public class User : BaseEntity
{
    private User() { }

    public User(string email, string passwordHash, UserRole role)
    {
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }

    private readonly List<Project> _projects = new();
    public IReadOnlyCollection<Project> Projects => _projects;

    public void AssignToProject(Project project)
    {
        if (_projects.Contains(project))
            return;
        _projects.Add(project);
    }
}