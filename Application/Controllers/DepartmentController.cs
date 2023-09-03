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

    public DepartmentsController(IDepartmentManager departmentManager) =>
        _departmentManager = departmentManager ?? throw new ArgumentNullException(nameof(departmentManager));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentsView>>> GetDepartments()
    {
        return Ok(await _departmentManager.GetAllDepartments());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentsView>> GetDepartment(int id)
    {
        var department = await _departmentManager.GetDepartmentById(id);
        return (department == null) ? NotFound() : Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentsView>> CreateDepartment(DepartmentModel departmentModel)
    {
        var departmentView = await _departmentManager.CreateDepartment(departmentModel);
        return Ok(departmentView);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartmentApi(int id, [FromBody] DepartmentModel departmentModel)
    {
        var updatedDepartment = await _departmentManager.UpdateDepartment(id, departmentModel);
        return (updatedDepartment == null) ? NotFound() : Ok(updatedDepartment);
    }

    [HttpDelete("{id}")]
    public async Task<Boolean> DeleteDepartment(int id)
    {
        var isDeleted = await _departmentManager.DeleteDepartment(id);
        return isDeleted;
    }
}