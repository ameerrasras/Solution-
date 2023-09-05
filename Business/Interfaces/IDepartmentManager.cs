using Business.Models;
using Business.Views;

namespace Business.Interfaces;

public interface IDepartmentManager
{
    Task<List<DepartmentsView>> GetAllDepartments();
    Task<DepartmentsView> GetDepartmentById(int id);
    Task<DepartmentsView> CreateDepartment(DepartmentModel model);
    Task<DepartmentsView> UpdateDepartment(int id, DepartmentModel model);
    Task<bool> DeleteDepartment(int id);
}

