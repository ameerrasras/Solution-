using Business.Interfaces;
using Business.Views;
using Business.Models;
using Microsoft.AspNetCore.Mvc;


namespace Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentManager _departmentManager;

    public DepartmentsController(IDepartmentManager departmentManager)=>

        _departmentManager = departmentManager ?? throw new ArgumentNullException(nameof(departmentManager));
    

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentsView>>> GetDepartments()
    {
        var departments = await _departmentManager.GetAllDepartments();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentsView>> GetDepartment(int id)
    {
        var department = await _departmentManager.GetDepartmentById(id);

        if (department == null)
            return NotFound();

        return Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentsView>> CreateDepartment(DepartmentModel departmentModel)
    {
        var departmentView = await _departmentManager.CreateDepartment(departmentModel);

        return CreatedAtAction(nameof(GetDepartment), new { id = departmentView.Id }, departmentView);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartmentApi(int id, [FromBody] DepartmentModel departmentModel)
    {
        var updatedDepartment = await _departmentManager.UpdateDepartment(id, departmentModel);

        if (updatedDepartment == null)
            return NotFound();

        return Ok(updatedDepartment);

      
    }


    [HttpDelete("{id}")]
    public async Task<Boolean> DeleteDepartment(int id)
    {
        var isDeleted = await _departmentManager.DeleteDepartment(id);

        if (!isDeleted)
            return false;

        return true;

    }
}
