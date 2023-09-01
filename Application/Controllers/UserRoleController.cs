using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Models;

namespace WebApi.Controllers;

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
        var roles = await _userRoleManager.GetAllUserRoles();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _userRoleManager.GetUserRoleById(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserRoleModel roleModel)
    {
        var newRole = await _userRoleManager.CreateUserRole(roleModel);
        if (newRole == null)
        {
            return BadRequest("Failed to create role");
        }
        return CreatedAtAction(nameof(GetById), new { id = newRole.Id }, newRole);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserRoleModel roleModel)
    {
        var updatedRole = await _userRoleManager.UpdateUserRole(id, roleModel);
        if (updatedRole == null)
        {
            return NotFound();
        }
        return Ok(updatedRole);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userRoleManager.DeleteUserRole(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
