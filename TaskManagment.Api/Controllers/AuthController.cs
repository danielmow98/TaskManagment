using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.Features.Auth.Login;
using TaskManagment.Application.Features.Auth.Register;

namespace TaskManagment.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly RegisterUserHandler _register;
    private readonly LoginUserHandler _login;
    
    public AuthController(RegisterUserHandler register, LoginUserHandler login)
    {
        _register = register;
        _login = login;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        await _register.HandleAsync(command);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var token = await _login.HandleAsync(command);
        return Ok(new {token});
    }
}