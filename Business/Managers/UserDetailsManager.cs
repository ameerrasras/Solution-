using Business.Interfaces;
using Infrastructure.Repository;
using Business.Mapping;
using Infrastructure.Entities;
using Infrastructure.Views;
#nullable disable

namespace Business.Managers;

public class UserDetailsManager : IUserDetailsManager
{
    private readonly IRepository<UserDetails> _repository;

    public UserDetailsManager(IRepository<UserDetails> repository)
    {
        _repository = repository;
    }

    public async Task<List<UserDetailsView>> GetAllUserDetails()
    {
        var userDetails = await _repository.GetAllAsync();
        return userDetails.Select(UserDetailsMapping.MapToView).ToList();
    }

    public async Task<UserDetailsView> GetUserDetailsById(int id)
    {
        var userDetails = await _repository.GetByIdAsync(id);
        return (userDetails == null || userDetails.IsDeleted) ? null : UserDetailsMapping.MapToView(userDetails);
    }

    public async Task<UserDetailsView> CreateUserDetails(UserDetailsModel model)
    {
        var entity = model.MapToEntity();
        entity.CreatedBy = "Ameer";
        entity.CreatedOn = DateTime.Now;
        entity.IsDeleted = false;
        var userDetail = await _repository.AddAsync(entity);
        entity.Id = userDetail.Id;

        return entity.MapToView();
    }

    public async Task<UserDetailsView> UpdateUserDetails(int id, UserDetailsModel model)
    {
        var existingUserDetails = await _repository.GetByIdAsync(id);

        if (existingUserDetails == null || existingUserDetails.IsDeleted)
            return null;

        existingUserDetails.FirstName = model.FirstName;
        existingUserDetails.LastName = model.LastName;
        existingUserDetails.Address = model.Address;
        existingUserDetails.Tel = model.Tel;
        existingUserDetails.ModifiedBy = "Ameer";
        existingUserDetails.ModifiedOn = DateTime.Now;

        await _repository.UpdateAsync(existingUserDetails);

        return existingUserDetails.MapToView();
    }

    public async Task<bool> DeleteUserDetails(int id)
    {
        var existingUser = await _repository.GetByIdAsync(id);

        if (existingUser == null)
            return false;

        existingUser.IsDeleted = true;
        await _repository.UpdateAsync(existingUser);

        return existingUser.IsDeleted;
    }
}
