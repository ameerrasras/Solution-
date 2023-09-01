﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Views;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Business.Interfaces;
namespace Business.Managers;

#nullable disable

public class UserManager : IUserManager
{
    private readonly MSDBcontext _context;

    public UserManager(MSDBcontext context) =>
        _context = context;

    public async Task<List<UserView>> GetAllUsers()
    {
        return await _context.Users
                             .Where(u => !u.IsDeleted)
                             .Select(u => new UserView
                             {
                                 Id = u.Id,
                                 UserId = u.UserId,
                                 Email = u.Email,
                                 RoleId = u.RoleId,

                             })
                             .ToListAsync();
    }

    public async Task<UserView> GetUserByUserId(string userId)
    {
        var user = await _context.Users
            .Where(u => u.UserId == userId && !u.IsDeleted)
            .FirstOrDefaultAsync();

        if (user == null)
            return null;

        return new UserView
        {
            Id = user.Id,
            UserId = user.UserId,
            Email = user.Email,
            RoleId = user.RoleId,
        };
    }

    public async Task<List<UserView>> GetUsersByRoleId(int roleId)
    {
        return await _context.Users
            .Where(u => u.RoleId == roleId && !u.IsDeleted)
            .Select(u => new UserView
            {
                Id = u.Id,
                UserId = u.UserId,
                Email = u.Email,
                RoleId = u.RoleId,
            })
            .ToListAsync();
    }


}
