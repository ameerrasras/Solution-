using Business.Models;
using Business.Views;
namespace Business.Interfaces;

    public interface IUserRoleManager
    {
        Task<List<UserRoleView>> GetAllUserRoles();
        Task<UserRoleView> GetUserRoleById(int userRoleId);
        Task<UserRoleView> CreateUserRole(UserRoleModel userRoleModel);
        Task<UserRoleView> UpdateUserRole(int userRoleId, UserRoleModel userRoleModel);
        Task<bool> DeleteUserRole(int userRoleId);
    }

