using Microsoft.EntityFrameworkCore;
using TaskManagment.Domain.Entities;
using TaskManagment.Application.Interfaces;
using TaskManagment.Infrastructure.Persistance;

namespace TaskManagment.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    private readonly AppDbContext _dbContext;
    
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.Include(u => u.Projects).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}