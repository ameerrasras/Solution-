using Business.Interfaces;
using Infrastructure.Repository;
using Business.Mapping;
using Business.Models;
using Business.Views;
using Infrastructure.Entities;
#nullable disable

namespace Business.Managers;

public class UserManager : IUserManager
{
    private readonly IRepository<User> _repository;

    public UserManager(IRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<List<UserView>> GetAllUsers()
    {
        var users = await _repository.GetAllAsync();
        return users.Select(UserMapping.MapToView).ToList();
    }

    public async Task<UserView> GetUserById(int userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        return (user == null || user.IsDeleted ) ? null : user.MapToView();

    }

    public async Task<UserView> CreateUser(UserModel model)
    {
        var entity = model.MapToEntity();
        entity.CreatedBy = "Ameer";
        entity.CreatedOn = DateTime.Now;
        entity.IsDeleted = false;
        var createdEntity = await _repository.AddAsync(entity); 

        return createdEntity.MapToView();
    }

    public async Task<UserView> UpdateUser(int Id, UserModel model)
    {
        var existingUser = await _repository.GetByIdAsync(Id);

        if (existingUser == null || existingUser.IsDeleted)
            return null;

        existingUser.Email = model.Email;
        existingUser.RoleId = model.RoleId;
        existingUser.Password = model.Password;
        existingUser.ModifiedBy = "Ameer";
        existingUser.ModifiedOn = DateTime.Now;

        await _repository.UpdateAsync(existingUser);

        return existingUser.MapToView();
    }

    public async Task<bool> DeleteUser(int id)
    {
        var existingUser = await _repository.GetByIdAsync(id);

        if (existingUser == null)
            return false;

        existingUser.IsDeleted = true;
    
        await _repository.UpdateAsync(existingUser);

        return existingUser.IsDeleted;
    }

    public async Task<List<UserView>> GetUsersByRoleId(int id)
    {
        var users = await _repository.GetAllAsync();

        if (users == null)
            return new List<UserView>(); 
       
        var filteredUsers = users.Where(u => u.RoleId == id).ToList();
        return filteredUsers.Select(UserMapping.MapToView).ToList();
    }
}
