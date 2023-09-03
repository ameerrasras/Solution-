using Business.Models;
using Business.Views;
namespace Business.Interfaces;
public interface IDepartmentManager
{
    Task<List<DepartmentsView>> GetAllDepartments();
    Task<DepartmentsView> GetDepartmentById(int departmentId);
    Task<DepartmentsView> CreateDepartment(DepartmentModel departmentModel);
    Task<DepartmentsView> UpdateDepartment(int departmentId, DepartmentModel departmentModel);
    Task<bool> DeleteDepartment(int departmentId);
}

