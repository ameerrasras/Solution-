using Infrastructure.Entities;
using Infrastructure.Views;

namespace Business.Interfaces;

public interface IUserDetailsManager
{
    Task<List<UserDetailsView>> GetAllUserDetails();
    Task<UserDetailsView> GetUserDetailsById(int id);
    Task<UserDetailsView> CreateUserDetails(UserDetailsModel model);
    Task<UserDetailsView> UpdateUserDetails(int id, UserDetailsModel model);
    Task<bool> DeleteUserDetails(int id);
}
