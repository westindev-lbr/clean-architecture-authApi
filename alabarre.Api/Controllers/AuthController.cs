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

    public AuthController()
    {
        
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req){
        return Ok(req);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req){
        return Ok(req);
    }


    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get() {
        return Ok("All good");
    }
} 