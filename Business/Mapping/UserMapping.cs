using Infrastructure.Entities;
using Business.Models;
using Business.Views;
namespace Business.Mapping;
#nullable disable
public static class UserMapping
{
    public static UserView MapToView(User entity)
    {
        if (entity == null)
            return null;

        return new UserView
        {
            Id = entity.Id,
            UserId = entity.UserId,
            Email = entity.Email,
            RoleId = entity.RoleId
        };
    }

    public static User MapToEntity(UserModel model)
    {
        if (model == null)
            return null;

        return new User
        {
            UserId = model.UserId,
            Email = model.Email,
            RoleId = model.RoleId,
            Password = model.Password
        };
    }
}
