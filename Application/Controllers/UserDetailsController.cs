using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Infrastructure.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserDetailsController : ControllerBase
{
    private readonly IUserDetailsManager _manager;

    public UserDetailsController(IUserDetailsManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _manager.GetAllUserDetails());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userDetails = await _manager.GetUserDetailsById(id);
        return userDetails == null ? NotFound("User details not found.") : Ok(userDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDetailsModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
 
        var newUserDetails = await _manager.CreateUserDetails(model);
        return newUserDetails == null ? BadRequest("Failed to create user details.") : Ok(newUserDetails);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserDetailsModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedUserDetails = await _manager.UpdateUserDetails(id, model);
        return updatedUserDetails == null ? NotFound("User details not found.") : Ok(updatedUserDetails);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _manager.DeleteUserDetails(id);
        return isDeleted ? Ok("Deleted successfully.") : BadRequest("Failed to delete.");
    }
}