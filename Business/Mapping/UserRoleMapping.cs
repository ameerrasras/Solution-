using Infrastructure.Entities;
using Business.Models;
using Business.Views;
#nullable disable

namespace Business.Mapping;

public static class UserRoleMapping 
{
    public static UserRoleView MapToView(this UserRole entity)
    {
        return (entity == null) ? null : new UserRoleView
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

    public static UserRole MapToEntity(this UserRoleModel model)
    {
        return (model == null) ? null : new UserRole
        {
            Name = model.Name,
            Description = model.Description
        };
    }
}
