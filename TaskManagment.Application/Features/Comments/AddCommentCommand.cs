namespace TaskManagment.Application.Features.Comments;

public record AddCommentCommand(Guid TaskId, Guid UserId, string Content);