using Business.Models;
using Business.Views;
using Business.Repositories;
using Business.Interfaces;
using Business.Mapping;

namespace Business.Managers;

public class UserRoleManager : IUserRoleManager
{
    private readonly IUserRoleRepository _repository;

    public UserRoleManager(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserRoleView>> GetAllUserRoles()
    {
        var userRoles = await _repository.GetAll();
        return userRoles.Select(ur => UserRoleMapping.MapToView(ur)).ToList();
    }

    public async Task<UserRoleView> GetUserRoleById(int userRoleId)
    {
        var userRole = await _repository.GetById(userRoleId);
        return UserRoleMapping.MapToView(userRole);
    }

    public async Task<UserRoleView> CreateUserRole(UserRoleModel userRoleModel)
    {
        var userRoleEntity = UserRoleMapping.MapToEntity(userRoleModel);
        var createdUserRole = await _repository.Create(userRoleEntity);
        return UserRoleMapping.MapToView(createdUserRole);
    }

    public async Task<UserRoleView> UpdateUserRole(int userRoleId, UserRoleModel userRoleModel)
    {
        var userRoleEntity = UserRoleMapping.MapToEntity(userRoleModel);
        var updatedUserRole = await _repository.Update(userRoleId, userRoleEntity);
        return UserRoleMapping.MapToView(updatedUserRole);
    }

    public async Task<bool> DeleteUserRole(int userRoleId)
    {
        return await _repository.Delete(userRoleId);
    }
}
