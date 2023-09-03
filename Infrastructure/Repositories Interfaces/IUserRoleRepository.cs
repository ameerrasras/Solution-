using Infrastructure.Entities;
namespace Business.Repositories;

public interface IUserRoleRepository
{
    Task<List<UserRole>> GetAll();
    Task<UserRole> GetById(int id);
    Task<UserRole> Create(UserRole userRole);
    Task<UserRole> Update(int id, UserRole userRole);
    Task<bool> Delete(int id);
}
