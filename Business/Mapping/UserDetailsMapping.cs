using Infrastructure.Entities;
using Infrastructure.Views;

namespace Business.Mapping;

#nullable disable
public static class UserDetailsMapping
{
    public static UserDetailsView MapToView(this UserDetails entity)
    {
        return (entity == null) ? null : new UserDetailsView
        {
            Id = entity.Id,
            UserId = entity.UserId,
            ProfilePictureUrl = entity.ProfilePictureUrl,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Address = entity.Address,
            Tel = entity.Tel,
            CreatedBy = entity.CreatedBy,
            CreatedOn = entity.CreatedOn,
            ModifiedBy = entity.ModifiedBy,
            ModifiedOn = entity.ModifiedOn
        };

    }

    public static UserDetails MapToEntity(this UserDetailsModel model)
    {
        return (model == null) ? null : new UserDetails
        {
            FirstName = model.FirstName,
            ProfilePictureUrl = model.ProfilePictureUrl,
            LastName = model.LastName,
            Address = model.Address,
            Tel = model.Tel,
            UserId = model.UserId
        };
    }
}