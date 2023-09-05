using Infrastructure.Entities;
using Business.Models;
using Business.Views;
namespace Business.Mapping;
#nullable disable
public static class UserRoleMapping 
{
    public static UserRoleView MapToView(UserRole entity)
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

    public static UserRole MapToEntity(UserRoleModel model)
    {
        return (model == null) ? null : new UserRole
        {
            Name = model.Name,
            Description = model.Description
        };
    }
}
