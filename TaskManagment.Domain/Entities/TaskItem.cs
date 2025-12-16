using TaskManagment.Domain.Common;
using TaskManagment.Domain.Enums;
using TaskStatus = TaskManagment.Domain.Enums.TaskStatus;
namespace TaskManagment.Domain.Entities;

public class TaskItem :BaseEntity
{
    private TaskItem() { }

    public TaskItem(string title, string description, DateTime dueDate, TaskPriority priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        Status = TaskStatus.Todo;
    }

    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public DateTime DueDate { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskStatus Status { get; private set; }

    private readonly List<Comment> _comments = new();
    public IReadOnlyCollection<Comment> Comments => _comments;
    
    public void ChangeStatus(TaskStatus status)
    {
        Status = status;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
}