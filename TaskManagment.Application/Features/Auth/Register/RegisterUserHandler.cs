using TaskManagment.Application.Interfaces;
using TaskManagment.Domain.Entities;
using TaskManagment.Domain.Enums;

namespace TaskManagment.Application.Features.Auth.Register;

public class RegisterUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _hasher;

    public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher hasher)
    {
        _userRepository = userRepository;
        _hasher = hasher;
    }

    public async Task HandleAsync(RegisterUserCommand command)
    {
        var hash = _hasher.Hash(command.Password);
        var user = new User(command.Email, hash, UserRole.User);
        await _userRepository.AddAsync(user);
    }
}