using Business.Interfaces;
using Business.Mapping;
using Business.Models;
using Business.Views;
using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace Business.Managers;
#nullable disable

    public class DepartmentManager : IDepartmentManager
    {
        private readonly MSDBcontext _context;

        public DepartmentManager(MSDBcontext context)=>
            _context = context;

    public async Task<List<DepartmentsView>> GetAllDepartments()
    {
        var departments = await _context.Departments
                                        .Where(d => !d.IsDeleted)
                                        .ToListAsync();

        return departments.Select(DepartmentMapping.MapToView).ToList();
    }



    public async Task<DepartmentsView> GetDepartmentById(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department == null || department.IsDeleted)
                return null;
        var DepartmentsView = DepartmentMapping.MapToView(department);

        return DepartmentsView;

        }


    public async Task<DepartmentsView> CreateDepartment(DepartmentModel departmentModel)
    {
        var departmentEntity = DepartmentMapping.MapToEntity(departmentModel);

        // these are additional fields that aren't in the model
        departmentEntity.CreatedBy = "Ameer";
        departmentEntity.CreatedOn = DateTime.Now;
        departmentEntity.ModifiedBy = "None";
        departmentEntity.ModifiedOn = DateTime.Now;
        departmentEntity.IsDeleted = false;

        _context.Departments.Add(departmentEntity);
        await _context.SaveChangesAsync();

        var DepartmentsView = DepartmentMapping.MapToView(departmentEntity);

        return DepartmentsView;
    }


    public async Task<DepartmentsView> UpdateDepartment(int departmentId, DepartmentModel departmentModel)
    {
        var department = await _context.Departments.FindAsync(departmentId);

        if (department == null || department.IsDeleted)
            return null;

        department.Name = departmentModel.Name;
        department.Description = departmentModel.Description;
        department.ModifiedBy = "Ameer";  
                        department.ModifiedOn = DateTime.Now;

        _context.Departments.Update(department);
        await _context.SaveChangesAsync();

        var DepartmentsView = DepartmentMapping.MapToView(department);

        return DepartmentsView;
    }


    public async Task<bool> DeleteDepartment(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department == null)
                return false;
            
            department.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }