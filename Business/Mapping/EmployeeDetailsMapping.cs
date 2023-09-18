using Infrastructure.Entities;
using business.Views;

namespace Business.Mapping;
#nullable disable
public static class EmployeeDetailsMapping
{
    public static EmployeeDetailsView MapToView (this EmployeeDetails entity)
    {
        return (entity == null) ? null : new EmployeeDetailsView
        {
            Id = entity.Id,
            DepartmentId = entity.DepartmentId,
            Salary = entity.Salary,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            UserId = entity.UserId,
            CreatedBy = entity.CreatedBy,
            CreatedOn = entity.CreatedOn,
            ModifiedBy = entity.ModifiedBy,
            ModifiedOn = entity.ModifiedOn
        };
    }

    public static EmployeeDetails MapToEntity(this EmployeeDetailsModel model)
    {
        return (model == null) ? null : new EmployeeDetails
        {
            DepartmentId = model.DepartmentId,
            Salary = model.Salary,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            UserId = model.UserId
        };
    }
}