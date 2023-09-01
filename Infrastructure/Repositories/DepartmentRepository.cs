using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


public class DepartmentRepository
{
    #nullable disable
    private readonly MSDBcontext _context;

    public DepartmentRepository(MSDBcontext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments
                             .Where(d => !d.IsDeleted)
                             .ToListAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task<int> AddAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department.Id;
    }

    public async Task<bool> UpdateAsync(Department department)
    {
        _context.Entry(department).State = EntityState.Modified;
        return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null)
            return false;

        department.IsDeleted = true;
        return (await _context.SaveChangesAsync()) > 0;
    }
}