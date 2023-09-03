using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DepartmentRepository : IDepartmentRepository
{
#nullable disable
    private readonly MSDBcontext _context;

    public DepartmentRepository(MSDBcontext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllDepartments()
    {
        return await _context.Departments
                             .Where(d => !d.IsDeleted)
                             .ToListAsync();
    }

    public async Task<Department> GetByIdDepartments(int id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task<Department> AddDepartments(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department> UpdateDepartments(Department department)
    {
        _context.Entry(department).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<bool> DeleteDepartments(Department department)
    {
        var existingDepartment = await _context.Departments.FindAsync(department.Id);
        if (existingDepartment == null)
            return false;
        existingDepartment.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
