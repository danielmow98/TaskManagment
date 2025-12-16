using Microsoft.EntityFrameworkCore;
using TaskManagment.Application.Interfaces;
using TaskManagment.Domain.Entities;
using TaskManagment.Infrastructure.Persistance;

namespace TaskManagment.Infrastructure.Repositories;

public class TaskRepository:ITaskRepository
{
    private readonly AppDbContext _dbContext;
    
    public TaskRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Tasks
            .Include(t => t.Comments)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(TaskItem task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();
    }
}