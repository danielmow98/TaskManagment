using TaskManagment.Domain.Entities;

namespace TaskManagment.Application.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(Guid id);
    Task AddAsync(Project project);
}