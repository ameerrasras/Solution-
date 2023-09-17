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
        return (userRole == null || userRole.IsDeleted) ? null : userRole.MapToView();
    }

    public async Task<UserRoleView> CreateUserRole(UserRoleModel model)
    {
        var entity = model.MapToEntity();
        entity.CreatedBy = "Ameer";
        entity.CreatedOn = DateTime.Now;
        entity.IsDeleted = false;

        var createdEntity = await _repository.AddAsync(entity);
        return createdEntity.MapToView();
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

        return existingUserRole.MapToView();
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
