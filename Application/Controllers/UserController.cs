using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserManager _manager;

    public UserController(IUserManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _manager.GetAllUsers());
    }

    [HttpGet("Role/{roleId}")]
    public async Task<IActionResult> GetUsersByRoleId(int id)
    {
        var usersWithRole = await _manager.GetUsersByRoleId(id);

        if (usersWithRole == null || !usersWithRole.Any())
            return NotFound("No users found for the given role ID.");

        return Ok(usersWithRole);
    }

    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _manager.GetUserById(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newUser = await _manager.CreateUser(model);
        return newUser == null ? BadRequest("Failed to create role") : Ok(newUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedUser = await _manager.UpdateUser(id, model);
        return updatedUser == null ? NotFound() : Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return ( await _manager.DeleteUser(id) ) ? Ok("Deleted Successfully") : BadRequest("Failed to delete");
    }
}
