using Infrastructure.Entities;
using Business.Models;
using Business.Views;
namespace Business.Mapping;
#nullable disable
public static class UserRoleMapping 
{
    public static UserRoleView MapToView(UserRole entity)
    {
        if (entity == null)
            return null;

        return new UserRoleView
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description
        };
    }

    public static UserRole MapToEntity(UserRoleModel model)
    {
        if (model == null)
            return null;

        return new UserRole
        {
            Name = model.Name,
            Description = model.Description
        };
    }
}
