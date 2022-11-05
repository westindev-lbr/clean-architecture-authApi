using alabarre.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace alabarre.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("all")]
    public IActionResult ListUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }
}
