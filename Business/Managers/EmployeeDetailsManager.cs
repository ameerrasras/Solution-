using Infrastructure.Repository;
using Business.Mapping;
using Infrastructure.Entities;
using business.Views;
using Business.Interfaces;
#nullable disable

namespace Business.Managers;

public class EmployeeDetailsManager : IEmployeeDetailsManager
{
    private readonly IRepository<EmployeeDetails> _repository;

    public EmployeeDetailsManager(IRepository<EmployeeDetails> repository)
    {
        _repository = repository;
    }

    public async Task<List<EmployeeDetailsView>> GetAllEmployeesDetails()
    {
        var employees = await _repository.GetAllAsync();
        return employees.Select(EmployeeDetailsMapping.MapToView).ToList();
    }

    public async Task<EmployeeDetailsView> GetEmployeeDetailsById(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        return (employee == null || employee.IsDeleted) ? null : employee.MapToView();
    }

    public async Task<EmployeeDetailsView> AddEmployeeDetails(EmployeeDetailsModel model)
    {
        var entity = model.MapToEntity();
        entity.CreatedBy = "Ameer";
        entity.CreatedOn = DateTime.Now;
        entity.IsDeleted = false;

        var createdEntity = await _repository.AddAsync(entity);

        return createdEntity.MapToView();
    }

    public async Task<EmployeeDetailsView> UpdateEmployeeDetails(int id, EmployeeDetailsModel model)
    {
        var existingEmployee = await _repository.GetByIdAsync(id);

        if (existingEmployee == null || existingEmployee.IsDeleted)
            return null;

        existingEmployee.DepartmentId = model.DepartmentId;
        existingEmployee.Salary = model.Salary;
        existingEmployee.StartDate = model.StartDate;
        existingEmployee.EndDate = model.EndDate;
        existingEmployee.ModifiedBy = "Ameer";
        existingEmployee.ModifiedOn = DateTime.Now;

        await _repository.UpdateAsync(existingEmployee);

        return existingEmployee.MapToView();
    }

    public async Task<bool> DeleteEmployeeDetails(int id)
    {
        var existingEmployeeDetails = await _repository.GetByIdAsync(id);

        if (existingEmployeeDetails == null)
            return false;

        existingEmployeeDetails.IsDeleted = true;

        await _repository.UpdateAsync(existingEmployeeDetails);

        return existingEmployeeDetails.IsDeleted;
    }
}