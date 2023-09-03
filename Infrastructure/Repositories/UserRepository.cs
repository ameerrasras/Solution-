using Business.Interfaces;
using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace Business.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MSDBcontext _context;

    public UserRepository(MSDBcontext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users
            .Where(u => !u.IsDeleted)
            .ToListAsync();
    }

    public async Task<User> GetUserByUserId(int userId)
    {
        return await _context.Users
            .Where(u => u.UserId == userId && !u.IsDeleted)
            .FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetUsersByRoleId(int roleId)
    {
        return await _context.Users
            .Where(u => u.RoleId == roleId && !u.IsDeleted)
            .ToListAsync();
    }
}
