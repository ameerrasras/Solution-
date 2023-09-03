using Infrastructure.Entities;
namespace Business.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserByUserId(int userId);
    Task<List<User>> GetUsersByRoleId(int roleId);
}
