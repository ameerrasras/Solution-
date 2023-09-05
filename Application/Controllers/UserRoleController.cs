using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Models;

namespace WebApi.Controllers;

#nullable disable
[ApiController]
[Route("[controller]")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleManager _manager;

    public UserRoleController(IUserRoleManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _manager.GetAllUserRoles());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var role = await _manager.GetUserRoleById(id);
        return (role == null) ? NotFound() : Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserRoleModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newRole = await _manager.CreateUserRole(model);
        return (newRole == null) ? BadRequest("Failed to create role") : Ok(newRole);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserRoleModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedRole = await _manager.UpdateUserRole(id, model);
        return (updatedRole == null) ? NotFound() : Ok(updatedRole);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _manager.DeleteUserRole(id);
        return result ? Ok("Deleted Successfully") : BadRequest("Failed to delete "); ;
    }
}
