using TaskManagment.Application.Interfaces;

namespace TaskManagment.Application.Features.Auth.Login;

public class LoginUserHandler
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public LoginUserHandler(IUserRepository users, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher hasher)
    {
        _users = users;
        _hasher = hasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> HandleAsync(LoginUserCommand command)
    {
        var user = await _users.GetByEmailAsync(command.Email) ?? throw new UnauthorizedAccessException();

        if (!_hasher.Verify(user.PasswordHash, command.Password))
            throw new UnauthorizedAccessException();
        
        return _jwtTokenGenerator.GenerateToken(user.Id,user.Email,user.Role.ToString());
    }
}