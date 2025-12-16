using TaskManagment.Domain.Entities;

namespace TaskManagment.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string email, string role);
}