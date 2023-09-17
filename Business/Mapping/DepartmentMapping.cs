using Infrastructure.Entities;
using Business.Models;
using Business.Views;

namespace Business.Mapping;

#nullable disable
public static class DepartmentMapping
{
    public static DepartmentsView MapToView(this Department entity)
    {
        return (entity == null) ? null : new DepartmentsView
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            CreatedBy = entity.CreatedBy,
            CreatedOn = entity.CreatedOn,
            ModifiedBy = entity.ModifiedBy,
            ModifiedOn = entity.ModifiedOn
        };
    }

    public static Department MapToEntity(this DepartmentModel model)
    {
        return (model == null) ? null : new Department
        {
            Name = model.Name,
            Description = model.Description,

        };
    }
}