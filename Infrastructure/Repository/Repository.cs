using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(MSDBcontext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            return await _dbSet.FindAsync(new object[] { id });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return default(T); 
        }
    }

    public async Task<IList<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<T>(); 
        }
    }

    public async Task<T> AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return default(T);
        }
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

}