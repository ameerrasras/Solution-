using Business.Models;
using Business.Views;

namespace Business.Interfaces;

public interface IUserManager
{
    Task<List<UserView>> GetAllUsers();
    Task<UserView> GetUserById(int id);
    Task<UserView> CreateUser(UserModel model);
    Task<UserView> UpdateUser(int id, UserModel model);
    Task<bool> DeleteUser(int id);
    Task<List<UserView>> GetUsersByRoleId(int id);
    string GenerateJwtToken(string email, string role);
    Task<string> GetRoleNameAsync(int roleId);

}
