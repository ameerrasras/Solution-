using Infrastructure.Entities;
using Business.Models;
using Business.Views;

namespace Business.Mapping;

#nullable disable
public static class UserMapping 
{
    public static UserView MapToView(this User entity)
    {
        return (entity == null) ? null : new UserView
        {
            Id = entity.Id,
            Email = entity.Email,
            RoleId = entity.RoleId,
            CreatedBy = entity.CreatedBy,
            CreatedOn = entity.CreatedOn,
            ModifiedBy = entity.ModifiedBy,
            ModifiedOn = entity.ModifiedOn
        };
    }

    public static User MapToEntity(this UserModel model)
    {
        return (model == null) ? null : new User
        { 
            Email = model.Email,
            RoleId = model.RoleId,
            Password = model.Password
        };
    }
}