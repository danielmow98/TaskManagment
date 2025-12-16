using TaskManagment.Domain.Entities;

namespace TaskManagment.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task AddAsync(TaskItem task);
}