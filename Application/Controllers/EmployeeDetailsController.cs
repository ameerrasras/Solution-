using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Infrastructure.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeDetailsController : ControllerBase
{
    private readonly IEmployeeDetailsManager _manager;

    public EmployeeDetailsController(IEmployeeDetailsManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _manager.GetAllEmployeesDetails());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employeeDetails = await _manager.GetEmployeeDetailsById(id);
        return employeeDetails == null ? NotFound("Employee details not found.") : Ok(employeeDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDetailsModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newEmployeeDetails = await _manager.AddEmployeeDetails(model);
        return newEmployeeDetails == null ? BadRequest("Failed to create employee details.") : Ok(newEmployeeDetails);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeDetailsModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedEmployeeDetails = await _manager.UpdateEmployeeDetails(id, model);
        return updatedEmployeeDetails == null ? NotFound("Employee details not found.") : Ok(updatedEmployeeDetails);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _manager.DeleteEmployeeDetails(id);
        return isDeleted ? Ok("Deleted successfully.") : BadRequest("Failed to delete.");
    }
}
