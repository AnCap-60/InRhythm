using InRhythmServer.Models;
using InRhythmServer.Services;
using InRhythmServer.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace InRhythmServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(TokenService tokenService, IUserService userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserCredentials creds)
    {
        if (!await userService.ValidateCredentialsAsync(creds.Username, creds.Password))
            return Unauthorized();

        var token = tokenService.GenerateToken(creds.Username);
        return Ok(new { token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCredentials creds)
    {
        if (await userService.GetByUsernameAsync(creds.Username) != null)
            return BadRequest("User already exists.");

        await userService.RegisterAsync(creds.Username, creds.Password);
        return Ok("Registered successfully.");
    }
}