using Business.Interfaces;
using Business.Mapping;
using Business.Models;
using Business.Views;

namespace Business.Managers;
#nullable disable
public class DepartmentManager : IDepartmentManager
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentManager(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<List<DepartmentsView>> GetAllDepartments()
    {
        var departments = await _departmentRepository.GetAllDepartments();
        return departments.Select(DepartmentMapping.MapToView).ToList();
    }

    public async Task<DepartmentsView> GetDepartmentById(int departmentId)
    {
        var department = await _departmentRepository.GetByIdDepartments(departmentId);
        if (department == null || department.IsDeleted)
            return null;

        return DepartmentMapping.MapToView(department);
    }

    public async Task<DepartmentsView> CreateDepartment(DepartmentModel departmentModel)
    {
        var departmentEntity = DepartmentMapping.MapToEntity(departmentModel);
        departmentEntity.CreatedBy = "Ameer";
        departmentEntity.CreatedOn = DateTime.Now;
        departmentEntity.IsDeleted = false;

        var department = await _departmentRepository.AddDepartments(departmentEntity);
        departmentEntity.Id = department.Id;

        return DepartmentMapping.MapToView(departmentEntity);
    }

    public async Task<DepartmentsView> UpdateDepartment(int departmentId, DepartmentModel departmentModel)
    {
        var department = await _departmentRepository.GetByIdDepartments(departmentId);
        if (department == null || department.IsDeleted)
            return null;

        department.Name = departmentModel.Name;
        department.Description = departmentModel.Description;
        department.ModifiedBy = "Ameer";
        department.ModifiedOn = DateTime.Now;

        await _departmentRepository.UpdateDepartments(department);

        return DepartmentMapping.MapToView(department);
    }

    public async Task<bool> DeleteDepartment(int departmentId)
    {
        var department = await _departmentRepository.GetByIdDepartments(departmentId);
        if (department == null)
            return false;

        department.IsDeleted = true;
        await _departmentRepository.UpdateDepartments(department);

        return true;
    }
}
