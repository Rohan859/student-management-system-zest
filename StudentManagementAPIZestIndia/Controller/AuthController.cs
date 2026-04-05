using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "User login", Description = "Authenticates a user and returns a JWT token.")]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "password")
        {
            var token = _jwtService.GenerateToken(username);
            return Ok(new { token });
        }

        return Unauthorized();
    }
}