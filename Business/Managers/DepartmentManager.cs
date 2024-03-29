﻿using Business.Interfaces;
using Business.Mapping;
using Business.Models;
using Business.Views;
using Infrastructure.Entities;
using Infrastructure.Repository;

namespace Business.Managers;

#nullable disable
public class DepartmentManager : IDepartmentManager
{
    private readonly IRepository<Department> _repository;

    public DepartmentManager(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public async Task<List<DepartmentsView>> GetAllDepartments()
    {
        return (await _repository.GetAllAsync())
            .Where(department => !department.IsDeleted)
            .Select(DepartmentMapping.MapToView)
            .ToList();
    }


    public async Task<DepartmentsView> GetDepartmentById(int id)
    {
        var department = await _repository.GetByIdAsync(id);
        return (department == null || department.IsDeleted) ? null: department.MapToView();
    }

    public async Task<DepartmentsView> CreateDepartment(DepartmentModel model)
    {
        var entity = model.MapToEntity();
        entity.CreatedBy = "Ameer";
        entity.CreatedOn = DateTime.Now;
        entity.IsDeleted = false;

        var department = await _repository.AddAsync(entity);
        entity.Id = department.Id;

        return entity.MapToView();
    }

    public async Task<DepartmentsView> UpdateDepartment(int id, DepartmentModel model)
    {
        var existingDepartment = await _repository.GetByIdAsync(id);

        if (existingDepartment == null || existingDepartment.IsDeleted)
            return null;

        existingDepartment.Name = model.Name;
        existingDepartment.Description = model.Description;
        existingDepartment.ModifiedBy = "Ameer";
        existingDepartment.ModifiedOn = DateTime.Now;

        await _repository.UpdateAsync(existingDepartment);

        return existingDepartment.MapToView();
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var existingDepartment = await _repository.GetByIdAsync(id);

        if (existingDepartment == null)
            return false;

        existingDepartment.IsDeleted = true;
 
        await _repository.UpdateAsync(existingDepartment);

        return existingDepartment.IsDeleted;
    }
}