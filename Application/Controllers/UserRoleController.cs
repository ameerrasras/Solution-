using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Models;
namespace WebApi.Controllers;
#nullable disable
[ApiController]
[Route("[controller]")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleManager _userRoleManager;
    public UserRoleController(IUserRoleManager userRoleManager)
    {
        _userRoleManager = userRoleManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userRoleManager.GetAllUserRoles());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _userRoleManager.GetUserRoleById(id);
        return (role == null) ? NotFound() : Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserRoleModel roleModel)
    {
        var newRole = await _userRoleManager.CreateUserRole(roleModel);
        return (newRole == null) ? BadRequest("Failed to create role") : Ok(roleModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserRoleModel roleModel)
    {
        var updatedRole = await _userRoleManager.UpdateUserRole(id, roleModel);
        return (updatedRole == null) ? NotFound() : Ok(updatedRole);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userRoleManager.DeleteUserRole(id);
        return(!result) ? NotFound(): NoContent();
    }
}
