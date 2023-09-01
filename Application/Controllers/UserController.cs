using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userManager.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("Role/{Rid}")]
    public async Task<IActionResult> GetUsersByRoleId(int Rid)
    {
        var usersWithRole = await _userManager.GetUsersByRoleId(Rid);
        if (usersWithRole == null || !usersWithRole.Any())
        {
            return NotFound();
        }
        return Ok(usersWithRole);
    }

    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _userManager.GetUserByUserId(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

}
