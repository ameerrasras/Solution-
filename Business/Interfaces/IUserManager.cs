using Business.Views;
namespace Business.Interfaces;

public interface IUserManager
{
    Task<List<UserView>> GetAllUsers();
    Task<UserView> GetUserByUserId(string userId);
    Task<List<UserView>> GetUsersByRoleId(int roleId);
}
