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
        return await _dbSet.FindAsync(new object[] { id });
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
