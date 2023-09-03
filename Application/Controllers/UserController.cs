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

    [HttpGet("Role/{RoleId}")]
    public async Task<IActionResult> GetUsersByRoleId(int RoleId)
    {
        var usersWithRole = await _userManager.GetUsersByRoleId(RoleId);
        return (usersWithRole == null || !usersWithRole.Any())? NotFound() : Ok(usersWithRole);
    }

    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userManager.GetUserByUserId(id);
        return (user == null) ? NotFound() : Ok(user);
    }
}
