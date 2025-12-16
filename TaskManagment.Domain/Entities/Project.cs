using TaskManagment.Domain.Common;

namespace TaskManagment.Domain.Entities;

public class Project:BaseEntity
{
    private Project() { }

    public Project(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    private readonly List<User> _users = new();
    public IReadOnlyCollection<User> Users => _users;

    private readonly List<TaskItem> _tasks = new();
    public IReadOnlyCollection<TaskItem> Tasks => _tasks;

    public void AddUser(User user)
    {
        if (!_users.Contains(user))
            return;
        _users.Add(user);
        user.AssignToProject(this);
    }

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }
}