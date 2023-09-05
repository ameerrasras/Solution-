namespace Infrastructure.Repository;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id);
    Task<IList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
}