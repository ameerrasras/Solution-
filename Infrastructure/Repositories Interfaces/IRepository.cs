#nullable disable
public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<int> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}
