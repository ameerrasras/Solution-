using Infrastructure.Entities;
using Business.Models;
using Business.Views;


namespace Business.Mapping;

public static class DepartmentMapping
{
#nullable disable
    public static DepartmentsView MapToView( Department entity)
    {
        if (entity == null)
            return null;

        return new DepartmentsView
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
        if (model == null)
            return null;
        

        return new Department
        {
            Name = model.Name,
            Description = model.Description,

        };
    }
}
