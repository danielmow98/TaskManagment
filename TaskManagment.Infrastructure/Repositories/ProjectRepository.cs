using Microsoft.EntityFrameworkCore;
using TaskManagment.Application.Interfaces;
using TaskManagment.Domain.Entities;
using TaskManagment.Infrastructure.Persistance;

namespace TaskManagment.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _dbContext;
    
    public ProjectRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Projects
            .Include(p => p.Users)
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Project project)
    {
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();
    }
}