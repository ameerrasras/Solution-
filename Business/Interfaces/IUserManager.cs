using Business.Views;
namespace Business.Interfaces;
public interface IUserManager
{
    Task<List<UserView>> GetAllUsers();
    Task<UserView> GetUserByUserId(int userId);
    Task<List<UserView>> GetUsersByRoleId(int roleId);
}
