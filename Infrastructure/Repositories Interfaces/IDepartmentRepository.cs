using Infrastructure.Entities;
#nullable disable
public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartments();
    Task<Department> GetByIdDepartments(int id);
    Task<Department> AddDepartments(Department entity);
    Task<Department> UpdateDepartments(Department entity);
    Task<bool> DeleteDepartments(Department id);
}
