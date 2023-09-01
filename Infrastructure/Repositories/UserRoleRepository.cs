using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;
using Infrastructure.Context;
#nullable disable

namespace Business.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly MSDBcontext _context;

    public UserRoleRepository(MSDBcontext context)
    {
        _context = context;
    }

    public async Task<List<UserRole>> GetAll()
    {
        return await _context.UserRoles
                             .Where(ur => !ur.IsDeleted)
                             .ToListAsync();
    }

    public async Task<UserRole> GetById(int id)
    {
        return await _context.UserRoles.FindAsync(id);
    }

    public async Task<UserRole> Create(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();
        return userRole;
    }

    public async Task<UserRole> Update(int id, UserRole userRole)
    {
        var existingUserRole = await _context.UserRoles.FindAsync(id);
        if (existingUserRole == null || existingUserRole.IsDeleted)
        {
            return null;
        }

        existingUserRole.Name = userRole.Name;
        existingUserRole.Description = userRole.Description;
        _context.UserRoles.Update(existingUserRole);
        await _context.SaveChangesAsync();
        return existingUserRole;
    }

    public async Task<bool> Delete(int id)
    {
        var userRole = await _context.UserRoles.FindAsync(id);
        if (userRole == null) return false;

        userRole.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
