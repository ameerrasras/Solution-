using Business.Interfaces;
using Business.Mapping;
using Business.Views;

namespace Business.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserView>> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsers();
        return users.Select(UserMapping.MapToView).ToList();
    }

    public async Task<UserView> GetUserByUserId(string userId)
    {
        var user = await _userRepository.GetUserByUserId(userId);
        return UserMapping.MapToView(user);

    }

    public async Task<List<UserView>> GetUsersByRoleId(int roleId)
    {
        var users = await _userRepository.GetUsersByRoleId(roleId);
        return users.Select(UserMapping.MapToView).ToList();
    }

}
