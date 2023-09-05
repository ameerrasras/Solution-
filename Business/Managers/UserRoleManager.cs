using Business.Models;
using Business.Views;
using Infrastructure.Repository;
using Business.Interfaces;
using Business.Mapping;
using Infrastructure.Entities;
#nullable disable

namespace Business.Managers;

public class UserRoleManager : IUserRoleManager
{
    private readonly IRepository<UserRole> _repository;

    public UserRoleManager(IRepository<UserRole> repository)
    {
        _repository = repository;
    }

    public async Task<List<UserRoleView>> GetAllUserRoles()
    {
        var userRoles = await _repository.GetAllAsync();
        return userRoles.Select(UserRoleMapping.MapToView).ToList();
    }

    public async Task<UserRoleView> GetUserRoleById(int id)
    {
        var userRole = await _repository.GetByIdAsync(id);
        return (userRole == null || userRole.IsDeleted) ? null : UserRoleMapping.MapToView(userRole);
    }

    public async Task<UserRoleView> CreateUserRole(UserRoleModel model)
    {
        var entity = UserRoleMapping.MapToEntity(model);
        entity.CreatedBy = "Ameer";
        entity.CreatedOn = DateTime.Now;
        entity.IsDeleted = false;

        var createdEntity = await _repository.AddAsync(entity);
        return UserRoleMapping.MapToView(createdEntity);
    }

    public async Task<UserRoleView> UpdateUserRole(int id, UserRoleModel model)
    {
        var existingUserRole = await _repository.GetByIdAsync(id);

        if (existingUserRole == null || existingUserRole.IsDeleted)
            return null;

        existingUserRole.Name = model.Name;
        existingUserRole.Description = model.Description;
        existingUserRole.ModifiedBy = "Ameer";
        existingUserRole.ModifiedOn = DateTime.Now;

        await _repository.UpdateAsync(existingUserRole);

        return UserRoleMapping.MapToView(existingUserRole);
    }

    public async Task<bool> DeleteUserRole(int id)
    {
        var existingUserRole = await _repository.GetByIdAsync(id);

        if (existingUserRole == null)
            return false;

        existingUserRole.IsDeleted = true;

        await _repository.UpdateAsync(existingUserRole);

        return existingUserRole.IsDeleted;
    }

}
