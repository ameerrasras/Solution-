using Business.Interfaces;
using Business.Views;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentManager _manager;

    public DepartmentsController(IDepartmentManager departmentManager) =>
        _manager = departmentManager ?? throw new ArgumentNullException(nameof(departmentManager));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentsView>>> GetDepartments()
    {
        return Ok(await _manager.GetAllDepartments());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentsView>> GetDepartment(int id)
    {
        var department = await _manager.GetDepartmentById(id);
        return (department == null) ? NotFound() : Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentsView>> CreateDepartment(DepartmentModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var departmentView = await _manager.CreateDepartment(model);
        return Ok(departmentView);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedDepartment = await _manager.UpdateDepartment(id, model);

        return (updatedDepartment == null) ? NotFound() : Ok(updatedDepartment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartmentApi(int id)
    {
        var isDeleted = await _manager.DeleteDepartment(id);
        return isDeleted ? Ok(new { message = "Deleted successfully" }) : NotFound(new { message = "Department not found" });
    }

}