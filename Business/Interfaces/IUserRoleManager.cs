using Business.Models;
using Business.Views;

namespace Business.Interfaces;

public interface IUserRoleManager
{
    Task<List<UserRoleView>> GetAllUserRoles();
    Task<UserRoleView> GetUserRoleById(int id);
    Task<UserRoleView> CreateUserRole(UserRoleModel model);
    Task<UserRoleView> UpdateUserRole(int id, UserRoleModel model);
    Task<bool> DeleteUserRole(int id);
}