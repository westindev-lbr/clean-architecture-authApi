using alabarre.Application.Services.Authentication;
using alabarre.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace alabarre.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase 
{
    /* private readonly ILogger<AuthController> _logger;
    public AuthController(ILogger<AuthController> logger) {
        _logger = logger;
    } */

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req){
        var authresult = _authService.Register(
            req.StudentNum,
            req.Email,
            req.FirstName,
            req.LastName,
            req.Password);

        var response = new AuthResponse(
            authresult.User.Id,
            authresult.User.FirstName,
            authresult.User.LastName,
            authresult.User.Email,
            authresult.User.StudentNum,
            authresult.Token);
        

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req){
        var authresult = _authService.Login(
            req.Email, 
            req.Password);

        var response = new AuthResponse(
            authresult.User.Id,
            authresult.User.FirstName,
            authresult.User.LastName,
            authresult.User.Email,
            authresult.User.StudentNum,
            authresult.Token);
        
        return Ok(response);
    }

} 