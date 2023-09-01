using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByUserId(string userId);
        Task<List<User>> GetUsersByRoleId(int roleId);
    }
}
