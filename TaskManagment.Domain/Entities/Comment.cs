using TaskManagment.Domain.Common;

namespace TaskManagment.Domain.Entities;

public class Comment : BaseEntity
{
    private Comment() { }

    public Comment(Guid userId, string content)
    {
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }
    
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
}